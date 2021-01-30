using System;

namespace ConsoleAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimationWorker animationWorker = new AnimationWorker();
            animationWorker.Start();
            Console.ReadKey();
        }
    }
}
