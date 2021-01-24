    public System.Reflection.Assembly Resolver(object sender, ResolveEventArgs args)
    {
                Assembly assembly;
                string strAssembly;
                strAssembly = args.Name.Split(',')[0].ToString();
                assembly = null;
                try
                {
                    Assembly assembly ;
                    if (strAssembly == 'OneDLL') 
                    {
                       assembly  = Assembly.Load(Properties.Resources.OneDLL);  
                    }
                    else if (strAssembly == 'AnotherDLL')
                    {
                       assembly  = Assembly.Load(Properties.Resources.AnotherDLL);  
                    }
                    else if (strAssembly == 'AnotherAnotherDLL')
                    {
                       assembly  = Assembly.Load(Properties.Resources.AnotherAnotherDLL);  
                    }
                    else
                    {
                       // do something
                       return assembly;
                    }
    
                    return assembly;
                }
                catch (Exception ex)
                {
                   // do something
                }
    
                return assembly;
    }
