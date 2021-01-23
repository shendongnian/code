    public async Task<ActionResult> ListAsync()
    {            
         ConnectionStringSettingsCollection ConnectionStrings = ConfigurationManager.ConnectionStrings;
         List<SiteInfoModel> lstSites = new List<SiteInfoModel>();
         Task<List<SiteInfoModel>>[] tasks = new Task<List<SiteInfoModel>>[ConnectionStrings.Count];
         for (int i = 0; i < ConnectionStrings.Count; i++)
         {
             tasks[i] = getSitesForInstanceAsync(ConnectionStrings[i]);
         }
            
         try
         {
             Task.WaitAll(tasks.ToArray());
         }
         catch (AggregateException) { }
         for (int ctr = 0; ctr < tasks.Length; ctr++)
         {
             if (tasks[ctr].Status == TaskStatus.Faulted)
                 Console.WriteLine("error occurred in {0}", ConnectionStrings[ctr].Name);
             else
             {
                 lstSites.AddRange(tasks[ctr].Result);
             }
                                      
         }
         
         return View("~/Views/Sites/List.cshtml", lstSites);
     }
    private Task<List<SiteInfoModel>> getSitesForInstanceAsync(ConnectionStringSettings css)
     {
         return Task.Run(() => getSitesForInstance(css));
     }
