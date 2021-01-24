    public class Options
    {
        public Options()
        {
            Load = new Dictionary<MySqlObjectType, bool>();
        }
        public Dictionary<MySqlObjectType, bool> Load { get; set; }
    }
