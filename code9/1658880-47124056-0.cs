    List<SetInstance> RelatedSets = (from proc in dc.Processes
                                 join sip in dc.SetInstanceProcessBindingInPIs 
                                    on proc.ID equals sip.ProcessID
                                 join si in dc.SetInstances 
                                    on sip.SetInstanceID equals si.ID
                                 where proc.StationID == StationID
                                 select new SetInstanceProcess { 
                                   SI = si, 
                                   Process = proc
                                 }
                                ).OrderByDescending(x => x.Process.FinishDate)
                                 .Select(x => x.SI)
                                 .Distinct()
                                 .Take(5)
                                 .ToList()
                                 .ConvertAll<SetInstance>(i => (SetInstance)i)
                                 .ToList();
