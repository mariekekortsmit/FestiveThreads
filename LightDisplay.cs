using System;
using System.Collections.Generic;

namespace FestiveThreads
{
    public class LightDisplay
    {
        private readonly char[][] _tree;
        private static readonly object _lock = new();
        private readonly CpuUsageMonitor _cpuUsageMonitor;
        private readonly List<(int, int)> _lightPositions;
        private readonly int _treeHeight = 10;

        public LightDisplay(int numCores, CpuUsageMonitor cpuUsageMonitor)
        {
            _cpuUsageMonitor = cpuUsageMonitor;
            _tree = CreateTree(_treeHeight);
            _lightPositions = DistributeCoresToLights(numCores);
            Console.CursorVisible = false;
            DrawInitialTree();
        }

        private static char[][] CreateTree(int height)
        {
            char[][] tree = new char[height][];
            for (int i = 0; i < height; i++)
            {
                int width = 2 * i + 1;
                tree[i] = new string(' ', height - i - 1).PadRight(height + i, 'O').ToCharArray();
            }
            return tree;
        }

        private List<(int, int)> DistributeCoresToLights(int numCores)
        {
            var positions = new List<(int, int)>();
            var random = new Random();

            // Identifying all possible light positions on the tree
            for (int i = 0; i < _tree.Length; i++)
            {
                for (int j = 0; j < _tree[i].Length; j++)
                {
                    if (_tree[i][j] == 'O')
                    {
                        positions.Add((i, j));
                    }
                }
            }

            // Randomly distribute cores to these positions
            var distributedPositions = new List<(int, int)>();
            while (distributedPositions.Count < numCores && distributedPositions.Count < positions.Count)
            {
                int randomIndex = random.Next(positions.Count);
                if (!distributedPositions.Contains(positions[randomIndex]))
                    distributedPositions.Add(positions[randomIndex]);
            }

            return distributedPositions;
        }



        private void DrawInitialTree()
        {
            Console.WriteLine("Christmas Tree Light Synchronization Simulator\n");
            for (int i = 0; i < _tree.Length; i++)
            {
                Console.WriteLine(new string(_tree[i]));
            }
            Console.WriteLine("\nCPU Usage: Initializing...");
            Console.WriteLine("Press Ctrl+C to exit.");
        }

        public void ToggleLight(int index)
        {
            lock (_lock)
            {
                if (index < _lightPositions.Count)
                {
                    var (y, x) = _lightPositions[index];
                    _tree[y][x] = _tree[y][x] == 'O' ? '*' : 'O';
                    UpdateTreeDisplay();
                }

                UpdateCpuUsageDisplay();
            }
        }

        private void UpdateTreeDisplay()
        {
            Console.SetCursorPosition(0, 3);
            for (int i = 0; i < _tree.Length; i++)
            {
                Console.WriteLine(new string(_tree[i]));
            }
        }

        private void UpdateCpuUsageDisplay()
        {
            Console.SetCursorPosition(0, _tree.Length + 5);
            Console.Write($"CPU Usage: {_cpuUsageMonitor.GetCurrentCpuUsage():F2}%                    ");
        }
    }
}
