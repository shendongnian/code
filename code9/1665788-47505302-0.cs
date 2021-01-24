            try
            {
            using (ServerManager manager = new ServerManager())
            {
                var iisManager = ServerManager.OpenRemote("YourServerName");
                Microsoft.Web.Administration.Site site = iisManager.Sites.Where(q => q.Name.Equals("YourSiteName")).FirstOrDefault();
               
                if (site.State== site.Start())
                {
                    site.Stop();
                }
                else
                {
                    site.Start();
                }
                manager.CommitChanges();
                
               
                }
               
            }
            catch (Exception ex)
                {
                }
        }
        
