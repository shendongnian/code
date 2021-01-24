         public MainPage()
         {
              InitializeComponent();
              this.BindingContext = new RootModel
              {
                  JobList = GetJobsInfo()
              };
         }
         private List<Jobs> GetJobsInfo()
         {
              var db = _connection.Table<Jobs>();
              return db.ToList();
         }
