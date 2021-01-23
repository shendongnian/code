    static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            {
                if (args.Name.Contains("ssisHelper"))
                {
                string path = @"c:\temp\";
                return System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(path, "ssisHelper.dll"));
            }
            else if (args.Name.Contains("xxx"))
                 {
                string path = @"c:\temp\";
                return System.Reflection.Assembly.LoadFile(System.IO.Path.Combine(path, "xxx.dll"));
            };    return null;
