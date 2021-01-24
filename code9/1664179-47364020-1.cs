    results_temp12 = (from workstation in _entitiesCTRS2.AidsM.OrderBy(c => c.Lab_ID)
                              join user_site in user.User_InvSites on workstation.Site_Number equals user_site.SITE_NO
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
