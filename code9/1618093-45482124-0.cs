    string SiteUrl = "The Website";
            System.Uri oUri = new System.Uri(SiteUrl);
            using (ClientContext oClientContext = new ClientContext(SiteUrl))
            {
                //Replace it with your user id for SharePoint Online
                string UserName = XXXXXXX;
                //Replace it with your password
                string Password = XXXXXXXXXXXXXX;
                oClientContext.Credentials = new NetworkCredential(UserName, Password);
                Console.WriteLine(oClientContext.Web.SiteGroups);
                oClientContext.Load(oClientContext.Web, w => w.SiteGroups.Include(o => o.Users.Include(l => l.LoginName), o => o.Title, o => o.Description, o => o.OwnerTitle));
                try
                {
                    oClientContext.ExecuteQuery();
                    Console.WriteLine("Connected");
                }
                catch (Exception e)
                {
                    Console.WriteLine("The error is \n" + e.Message);
                    Console.WriteLine("The source is \n" + e.Source);
                    Console.WriteLine("The Stack Trace is \n" + e.StackTrace);
                }
                GroupCollection oSiteCollectionGroups = oClientContext.Web.SiteGroups;              
                Console.WriteLine("List of groups in the site collection");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine(oSiteCollectionGroups.AreItemsAvailable);
                foreach (Group oGroup in oSiteCollectionGroups)
                {
                    Console.WriteLine(oGroup.Title);
                }
                Console.WriteLine("<<<<<<<<<<===================|End of Groups|========================>>>>>>>");                
                Console.WriteLine("List of users in the first group of site-collection");
                Console.WriteLine("-------------------------------------------------------");              
                for (int i = 1; i < oSiteCollectionGroups.Count; i++)
                {
                    Console.WriteLine("Items Available =>" + oSiteCollectionGroups[i].Users.AreItemsAvailable);
                    Console.WriteLine(oSiteCollectionGroups[i].Description);
                    Console.WriteLine(oSiteCollectionGroups[i].LoginName);
                    Console.WriteLine(oSiteCollectionGroups[i].Title);
                    Console.WriteLine("Owner Title =>" + oSiteCollectionGroups[i].OwnerTitle);                    
                    try
                    {
                        foreach (User oUser in oSiteCollectionGroups[i].Users)
                        {
                            Console.WriteLine(oUser.Title);
                            Console.WriteLine("n");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception Occured");
                        Console.WriteLine("The error is \n" + e.Message);
                        Console.WriteLine("The source is \n" + e.Source);
                        Console.WriteLine("The Stack Trace is \n" + e.StackTrace);
                    }
                }
                Console.WriteLine("<<<<<<<<<<===================|End of Memebers|========================>>>>>>>");
                Console.ReadLine();
            }
