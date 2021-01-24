    class C {
        IDataProvider _dataProvider;
        public C(IDataProvider provider)
        {
            // This has no knowledge about DataProvider, it only cares
            // about this being an instance of an object that implements 
            // the signature "GetPath()":
            _dataProvider = provider;
        }
        private void Sample()
        {            
            string path = _dataProvider.GetPath();
        }
    }
