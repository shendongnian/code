    public Tuple<int, TimeSpan> MonitorProcess(Process process)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        process.WaitForExit();
        stopwatch.Stop();
        return Tuple.Create(process.Id, stopwatch.Elapsed);
    }
    public void LaunchProcess(String processFullPath)
    {
        try
        {
            var tasks = new List<Task<Tuple<int,TimeSpan>>>();
            Process process = Process.Start(processFullPath);
            if (process == null) return;
            
            // Add my current (parent) process
            tasks.Add(Task.Factory.StartNew(()=>this.MonitorProcess(process)));
            var childProcesses = new List<Process>();
            while (!process.HasExited)
            {
                // Find new child-processes
                var mos = new ManagementObjectSearcher($"Select * From Win32_Process Where ParentProcessID={process.Id}");
                List<Process> newChildren = mos.Get().Cast<ManagementObject>().Select(mo => new { PID = Convert.ToInt32(mo["ProcessID"]) })
                    .Where(p => !childProcesses.Exists(cp => cp.Id == p.PID)).Select(p => Process.GetProcessById(p.PID)).ToList();
                // measure their execution time in different task
                tasks.AddRange(newChildren.Select(newChild => Task.Factory.StartNew(() => this.MonitorProcess(newChild))));
                childProcesses.AddRange(newChildren);
            }
            
            // Print the results
            StringBuilder sb = new StringBuilder();
            foreach (Task<Tuple<int, TimeSpan>> task in tasks) {
                sb.AppendLine($"[{task.Result.Item1}] - {task.Result.Item2}");
            }
            this.output.WriteLine(sb.ToString());
        }
        catch (Exception ex)
        {
            
        }
    }
