    public class Options
    {
        public Options()
        {
            Load = new Dictionary<MySqlobjectType, bool>();
        }
        public Dictionary<MySqlObjectType, bool> Load { get; set; }
    }
