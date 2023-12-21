using System;
using System.Management;
using System.Runtime.InteropServices;

namespace FestiveThreads
{
    class Program
    {
        static async Task Main()
        {
            int numCores = GetPhysicalCoreCount();
            Console.WriteLine($"Number of Physical Cores: {numCores}\n");

            CpuUsageMonitor cpuMonitor = new();
            LightDisplay display = new(numCores, cpuMonitor);

            Task[] tasks = new Task[numCores];
            for (int i = 0; i < numCores; i++)
            {
                tasks[i] = new LightController(i, display).ControlLightAsync();
            }

            await Task.WhenAll(tasks);
        }
        private static int GetPhysicalCoreCount()
        {
            int cores = 0;
            // If Windows, get the physical core count from WMI
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                ManagementObjectSearcher searcher = new("Select NumberOfCores from Win32_Processor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    // Retrieve the NumberOfCores property and cast it to UInt32, then to int
                    cores = (int)(UInt32)obj["NumberOfCores"];
                }
            }
            // If not Windows, get the number of processors from the Environment
            else
            { 
                cores = Environment.ProcessorCount;
            }
            return cores;
        }
    }
}
