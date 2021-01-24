    List<TcpProcessRecord> processes = Tcp.GetAllTcpConnections();
                var filteredAnonType = processes.Where(n => n.ProcessName.ToLower().StartsWith(Properties.Settings.Default.ProcessToMonitor.ToLower()))
                                        .GroupBy(x => x.ProcessId).Select(group => new
                                        {
                                            NumberConnections = group.Select(t => t.RemoteAddress).Distinct().Count(),
                                            ProcessID = group.Key,
                                        }).Where(v => v.NumberConnections < Properties.Settings.Default.MinimumConnections);
                List<ProcessZombie> filteredProcesses = (from zombie in filteredAnonType
                                                         select new ProcessZombie(zombie.NumberConnections, zombie.ProcessID)).ToList();
