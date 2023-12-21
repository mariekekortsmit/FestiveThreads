using System;
using System.Threading.Tasks;

namespace FestiveThreads
{
    public class LightController
    {
        private readonly int _index;
        private readonly LightDisplay _display;

        public LightController(int index, LightDisplay display)
        {
            _index = index;
            _display = display;
        }

        public async Task ControlLightAsync()
        {
            Random rnd = new();

            while (true) // Infinite loop for continuous operation
            {
                _display.ToggleLight(_index);
                await Task.Delay(rnd.Next(100, 500)); // Random delay to simulate blinking

                // CPU-intensive operation
                PerformCpuIntensiveTask();
            }
        }

        private void PerformCpuIntensiveTask()
        {
            // Simple CPU-intensive task: Calculate prime numbers
            long number = 2;
            int count = 0;
            while (count < 1000)
            {
                if (IsPrime(number))
                {
                    count++;
                }
                number++;
            }
        }

        private bool IsPrime(long number)
        {
            if (number < 2) return false;
            for (long i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
