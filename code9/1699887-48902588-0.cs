        protected const string mxMainDLLPath = @"libs\v40\Main_40.dll";
        dynamic mainObj = null;
        public ClientClass()
        {
            Assembly assembly = Assembly.LoadFrom(mxMainDLLPath );
            Type T = assembly.GetType("Main_40.Export");
            mainObj = Activator.CreateInstance(T);
        }
