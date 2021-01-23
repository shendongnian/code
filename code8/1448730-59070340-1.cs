    var   memorielines= GetWmicOutput("OS get FreePhysicalMemory,TotalVisibleMemorySize /Value").Split("\n");
            var freeMemory= memorielines[0].Split("=", StringSplitOptions.RemoveEmptyEntries)[1];
            var totalMemory = memorielines[1].Split("=", StringSplitOptions.RemoveEmptyEntries)[1];
            var cpuLines = GetWmicOutput("CPU get Name,LoadPercentage /Value").Split("\n");
            var CpuUse = cpuLines[0].Split("=", StringSplitOptions.RemoveEmptyEntries)[1];
            var CpuName = cpuLines[1].Split("=", StringSplitOptions.RemoveEmptyEntries)[1];
      
        private string GetWmicOutput(string query, bool redirectStandardOutput = true)
        {
            var info = new ProcessStartInfo("wmic");
            info.Arguments = query;
            info.RedirectStandardOutput = redirectStandardOutput;
            var output = "";
            using (var process = Process.Start(info))
            {
                output = process.StandardOutput.ReadToEnd();
            }
            return output.Trim();
        }
