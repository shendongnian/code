    results_temp12 = (from workstation in _entitiesCTRS2.AidsM.OrderBy(c => c.Lab_ID)
                              where user.User_InvSites.ToList().Any(c => c.Inv_Site.SITE_NO == workstation.Site_Number)
                              //where user.User_InvSites.ToList().ForEach(c => c.Inv_Site.SITE_NO.Where(w => workstation.Site_Number == c.Inv_Site.SITE_NO).ToList())
                              select new StudentSite
                              {
                                  firstname = workstation.First_Name,
                                  CreatedDate = workstation.Entered_dt,
                                  scanid = workstation.Scan_ID,
                                  labid = workstation.Lab_ID,
                                  SiteNo = workstation.Site_Number,
                                  DateReceived = workstation.Date_Received,
                                  DataEntryUser = workstation.Entered_By
                              }).ToList();
