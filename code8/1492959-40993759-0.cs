    public ObservableCollection<ConfigurationDetails> ConfigDetails { get; set; } 
    public ConfigurationWindow()
    {
       InitializeComponent();
       using (_db = new MyEntities())
       {
          var configRecords = _db.tblConfigs.ToList().Select(x => new ConfigurationDetails()
         {
              ConfigFName = x.ConfigFName,
              ConfigSName = x.ConfigSName,
              ConfigUName = x.ConfigUName,
              Id = x.ConfigID
         });
         foreach(var config in configRecords)
         { 
            model.ConfigDetails.Add(config);
          }
        
        }
     }
 }
