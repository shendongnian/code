         private static bool CheckConnection ()
                {
                    bool flag = false;
                    try
                    {
                        using (var context = new ApplicationDbContext())
                        {
        
        
                            if (context.Users.FirstOrDefault() != null)
                            {
                                // thismeans all is well on DBContext
                                flag= true;
                            }
                        }
                    }
                    catch( Exception t )
                    {
                        Debug.WriteLine("Error connecting to DB ");
                        flag= false;
                    }
                    return flag;
                }
    
    
    // use it like this in global.assax.cs 
    
    
     protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                GlobalConfiguration.Configure(WebApiConfig.Register);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
    
               if( CheckConnection())
                {
                    // set session variable of something else to show to user
                }
            }
