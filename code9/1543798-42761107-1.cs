    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    public static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            //debug and check the name
            if (args.Name == "MyDllName")
                return Assembly.LoadFrom("c:\\pathdll\midllv1.dll")
            else if(args.Name ="MyDllName2")
                return Assembly.LoadFrom("c:\\pathdll\midllv2.dll");
            else
                return Assembly.LoadFrom("");
        }
