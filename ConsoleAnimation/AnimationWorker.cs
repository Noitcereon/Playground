using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAnimation
{
    class AnimationWorker
    {
        public async void Start()
        {
            await Task.Run(PerformLoadAnimation);
            Console.WriteLine("Done.");
        }

        private void PerformLoadAnimation()
        {
            int numberOfTimesToAnimate = 0;

            while (numberOfTimesToAnimate <= 10)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write('*');
                    Thread.Sleep(200);
                }
                Console.Clear();
                numberOfTimesToAnimate++;
            }
        }
    }
}
