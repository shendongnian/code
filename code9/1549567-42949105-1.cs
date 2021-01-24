        static int Main(string[] args)
        {
            //we set an event handler at the begging of our program
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            //your stuff
        }
        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            //if the dll is a sqlserver dll, we do our trick
            if(args.Name.StartsWith("Microsoft.SqlServer"))
                return LoadSqlAssembly(args.Name);
            return null;
        }
        private static readonly int[] SqlVersions = new int[] {14, 13, 12, 11};
        private static bool _reEntry = false;
        private static Assembly LoadSqlAssembly(string name)
        {
            if (_reEntry)
                return null;
            name = name.Split(',')[0];
            foreach (var version in SqlVersions)
            {
                try
                {
                    _reEntry = true;
                    var ret = Assembly.Load($"{name}, Version={version}.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91, processorArchitecture=MSIL");
                    //Logger.InfoFormat("Loaded {0} version {1}", name, version);
                    return ret;
                }
                catch (Exception)
                {
                    //ignore exception
                }
                finally
                {
                    _reEntry = false;
                }
            }
            return null;
        }
  [1]: https://stackoverflow.com/a/40270649/789165
