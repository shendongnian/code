     var projects = (from p in _ProjectRep.GetAll()
                            join cl in _ClientRepo.GetAll() on p.ClientID equals cl.ClientID
                            where p.IsOpen == true && p.Tasks.Any(t => t.TimeEntries.Any(te => te.DateEntity >= dateLimit)) == false && p.Tasks.Any(te => te.TimeEntries.Any())
                            select new {
                                Project = p,
                                ClientName = cl.ClientName
                                
                            }).ToList();
