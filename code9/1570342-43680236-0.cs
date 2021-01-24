    public partial class DataClassesDataContext : DataContext
    {
        public DataClassesDataContext() : base(ConfigurationManager.ConnectionStrings["PSDataClasses.Properties.Settings.DBConnectionString"].ConnectionString)
        {
            OnCreated();
        }
    }
