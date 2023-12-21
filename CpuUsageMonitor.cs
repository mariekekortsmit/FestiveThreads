using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FestiveThreads
{
    public class CpuUsageMonitor
    {
        private readonly PerformanceCounter? cpuCounter;

        public CpuUsageMonitor()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {

                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            }
        }

        public float GetCurrentCpuUsage()
        {
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) && cpuCounter != null)
                return cpuCounter.NextValue();
            else
            {
                return 0;
            }
        }
    }
}
