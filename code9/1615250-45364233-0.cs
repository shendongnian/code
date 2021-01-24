As per the suggestion of L.B., I tried a simple If/then block using args.name. This has done the trick. 
    if (args.Name == "MyDll1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MyApplication.Resources.MyDLL1.dll"))
                {
                    byte[] assemblyData = new byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            }
            else if (args.Name == "MyDll2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MyApplication.Resources.MyDll2.dll"))
                {
                    byte[] assemblyData = new byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            }
