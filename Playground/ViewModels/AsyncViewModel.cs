using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Playground.Annotations;
using Playground.Common;

namespace Playground.ViewModels
{
    public class AsyncViewModel : INotifyPropertyChanged
    {
        private RelayCommand _runSyncCommand;
        private RelayCommand _runAsyncCommand;
        private double _elapsedMs;
        private int _iterationCounter;

        // other testing
        private string _name;


        public AsyncViewModel()
        {
            _elapsedMs = 0;
            _iterationCounter = 0;
            _runSyncCommand = new RelayCommand(RunSync);
            _runAsyncCommand = new RelayCommand(RunAsync);
            _name = "Default";
        }

        public RelayCommand RunSyncCommand
        {
            get { return _runSyncCommand; }
        }

        public RelayCommand RunAsyncCommand
        {
            get { return _runAsyncCommand; }
        }

        // Name is for other testing purposes.
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged();}
        }

        public int IterationCounter
        {
            get { return _iterationCounter; }
            set { _iterationCounter = value; OnPropertyChanged(); }
        }

        public double ElapsedMs
        {
            get { return _elapsedMs; }
            set { _elapsedMs = value; OnPropertyChanged(); }
        }

        public void RunSync()
        {
            IterationCounter = 0;
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();

            CountUp();

            stopWatch.Stop();
            ElapsedMs = stopWatch.ElapsedMilliseconds;
        }

        public async void RunAsync()
        {
            IterationCounter = 0;
            var stopWatch = System.Diagnostics.Stopwatch.StartNew();

            await Task.Run(() => CountUp());

            stopWatch.Stop();
            ElapsedMs = stopWatch.ElapsedMilliseconds;
        }

        private Int32 CountUp()
        {
            while (IterationCounter < 99999)
            {
                IterationCounter++;
            }

            return IterationCounter;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
