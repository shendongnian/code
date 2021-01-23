    var newStructList = myStructList.GroupBy(smj => new { smj.MailID, smj.ResendCount })
                                    .Select(grp => new 
                                    { 
                                        MailID = grp.Key.MailID,
                                        ResendCount = grp.Key.ResendCount
                                        MailJobs = grp.Select(x=>new 
                                                   {
                                                       x.ID,
                                                       x.PageCount
                                                   }).ToList() 
                                    })
                                    .ToList();
