        public string DBPath
        {
            get
            {
              return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbName.sqlite");
            }
        }
