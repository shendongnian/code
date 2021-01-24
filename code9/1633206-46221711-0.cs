    var assemlies = Assembly.GetEntryAssembly().GetReferencedAssemblies();
            var assemblyName = "";
            foreach (var item in assemlies)
            {
                if (item.Name == "RefProj")
                    assemblyName = item.Name;
            }
            var path = new FileInfo(Assembly.GetExecutingAssembly().Location);
            var a = Assembly.LoadFile(Path.Combine($@"{path}\..\..\..\..\..\RefProj\bin\Debug\netstandard2.0", "RefProj.dll"));
            var t = a.GetType("RefProj.Class1");
            var i = Activator.CreateInstance(t);
            MethodInfo mi = t.GetMethod("get1");
            mi.Invoke(i, null);
