         AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
     }
     static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
     {
         if (args.Name.Contains("ssisHelper"))
         {
             string path = @"c:\temp\";
             return System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(path, "ssisHelper.dll"));
         }
         return null;
     }
