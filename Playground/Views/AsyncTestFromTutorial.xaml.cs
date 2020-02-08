using System;
using System.Net;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Playground.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Playground.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AsyncTestFromTutorial : Page
    {
        public AsyncTestFromTutorial()
        {
            InitializeComponent();
        }

        private void Button_executeSync_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

            RunDownloadSync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            TextBlock_elapsedMs.Text += $"Execution time in ms: {elapsedMs}";
        }

        private async void Button_executeAsync_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

            await RunDownloadParallelAsync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            TextBlock_elapsedMs.Text += $"Execution time in ms: {elapsedMs}";
        }

        private List<string> PrepData()
        {
            List<string> prepData = new List<string>();

            // Maybe change location of this line of code?
            TextBlock_results.Text = "";

            prepData.Add("https://www.yahoo.com");
            prepData.Add("https://www.google.com");
            prepData.Add("https://www.facebook.com");
            prepData.Add("https://www.cnn.com");
            prepData.Add("https://www.youtube.com");

            return prepData;
        }

        private void RunDownloadSync()
        {
            List<string> websites = PrepData();

            foreach (string website in websites)
            {
                WebsiteDataModel results = DownloadWebsite(website);
                ReportWebsiteInfo(results);
            }
        }

        /// <summary>
        /// Runs the tasks one at a time, but reports them as soon as one task is done. Same speed as normal sync, but reports as progress is done.
        /// </summary>
        /// <returns></returns>
        private async Task RunDownloadAsync()
        {
            List<string> websites = PrepData();

            foreach (string website in websites)
            {
                WebsiteDataModel results =  await Task.Run(() => DownloadWebsite(website));
                ReportWebsiteInfo(results);
            }
        }
        /// <summary>
        /// Runs the tasks (downloads) simultaneously. Posts all the results at once. (double speed of normal syncronous method)
        /// </summary>
        /// <returns></returns>
        private async Task RunDownloadParallelAsync()
        {
            List<string> websites = PrepData();
            List <Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();

            // "Easier to implement" (no need to use WebClient's build-in asyncmethod in DownloadWebsiteAsync.
            //foreach (string website in websites)
            //{
            //    tasks.Add(Task.Run(() => DownloadWebsite(website)));
            //}

            foreach (string website in websites)
            {
                tasks.Add(DownloadWebsiteAsync(website));
            }

            var results = await Task.WhenAll(tasks);

            foreach (var item in results)
            {
                ReportWebsiteInfo(item);
            }
        }

        private WebsiteDataModel DownloadWebsite(string websiteUrl)
        {
            WebsiteDataModel websiteDataModel = new WebsiteDataModel();
            WebClient client = new WebClient();

            websiteDataModel.WebsiteUrl = websiteUrl;
            websiteDataModel.WebsiteData = client.DownloadString(websiteUrl);

            return websiteDataModel;
        }

        private async Task<WebsiteDataModel> DownloadWebsiteAsync(string websiteUrl)
        {
            WebsiteDataModel websiteDataModel = new WebsiteDataModel();
            WebClient client = new WebClient();

            websiteDataModel.WebsiteUrl = websiteUrl;
            websiteDataModel.WebsiteData =  await client.DownloadStringTaskAsync(websiteUrl);

            return websiteDataModel;
        }

        private void ReportWebsiteInfo(WebsiteDataModel data)
        {
            TextBlock_results.Text += $"{data.WebsiteUrl} downloaded: {data.WebsiteData.Length} characters long. {Environment.NewLine}";
        }
    }
}
