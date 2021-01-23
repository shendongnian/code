      public class FixtureItem
    {
        [PrimaryKey, AutoIncrement]
        public int CompetitionID { get; set; }
        public DateTime Date { get; set; }
        public int KickOff { get; set; }
        public int HomeTeamID { get; set; }
        public int AwayTeamID { get; set; }
    }
    public class Fixtures_SQLiteDB
    {
        private string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDataBase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "SphereSports.db")))
                {
                    connection.CreateTable<FixtureItem>();
                    //connection.Execute("Drop TABLE [Person]", "");
                    connection.CreateTable<FixtureItem>();
                    List<FixtureItem> newList = new List<FixtureItem>
                    {
                        //sample data
                        new FixtureItem{AwayTeamID = 2, HomeTeamID =4, Date = DateTime.Now, KickOff = 1400},
                        new FixtureItem{AwayTeamID = 2, HomeTeamID =4, Date = DateTime.Now, KickOff = 1400},
                        new FixtureItem{AwayTeamID = 2, HomeTeamID =4, Date = DateTime.Now, KickOff = 1400}
                    };
                    connection.InsertAll(newList);
           
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return false;
            }
        }
        public List<FixtureItem> selectTableFixtureItem()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "SphereSports.db")))
                {
                    return connection.Table<FixtureItem>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Log.Info("SQLiteEx", ex.Message);
                return null;
            }
        }
    }
