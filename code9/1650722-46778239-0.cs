    public class RosterData
    {
        public int id {get;set;}
        public DateTime cal_date {get;set;}
    }
    public List<RosterData> RetrieveToolRoster()
    {
        string List<RosterData> result = new List<RosterData>();
        string db_command = "SELECT [id], [cal_date] FROM inventory WHERE [cal_date] IS NOT NULL ORDER BY [id] ASC;";
        using(SQLiteConnection db_connection = new SQLiteConnection(Properties.Settings.Default.db_connectionstring))
        using(SQLiteCommand cmd = new SQLiteCommand(db_command, db_connection))
        {
            try
            {
                db_connection.Open();
                using(SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        RosterData rd = new RosterData()
                        {
                            rd.id = Convert.ToInt32(rd["id"]);
                            rd.cal_date = Convert.ToDateTime(rd["cal_date"]);
                        };
                        result.Add(rd);
                   }
               }
               return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\r\n" + ex.Message);
                return null;
            }
    
        }
    }
    .......
    private List<RosterData> _toolRoster;
    public List<RosterData> ToolRoster
    {
        get { return _toolRoster; }
        set
        {
            _toolRoster = value;
            NotifyOfPropertyChange(() => ToolRoster);
        }
    }
