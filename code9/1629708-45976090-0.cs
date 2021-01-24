        public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Xceed.Wpf.DataGrid.Licenser.LicenseKey = "XXXXX-XXXXX-XXXXX-XXXX";
            DataSet musicDataSet = Xceed.Wpf.DataGrid.Samples.SampleData.DataProvider.GetMusicLibraryDataSet();
            m_songs = musicDataSet.Tables["Songs"];
            base.OnStartup(e);
        }
        private DataTable m_songs;
        public DataTable Songs
        {
            get
            {
                return m_songs;
            }
        }
    }
