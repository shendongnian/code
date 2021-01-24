    var dirInfoUsingPublicConstructor = new DirectoryInfo(@"C:\Test");
    Console.WriteLine(dirInfoUsingPublicConstructor.ToString());
    
    var ctor = typeof(DirectoryInfo).GetConstructors(BindingFlags.NonPublic 
                                                    | BindingFlags.Instance).First();
    var dirInfoUsingInternalConstructor = 
                ctor.Invoke(new object[] { @"C:\Test", false }) as DirectoryInfo;
    Console.WriteLine(dirInfoUsingInternalConstructor.ToString());
