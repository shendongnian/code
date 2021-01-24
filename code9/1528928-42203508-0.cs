    public class Test : JObject
    {
        public int Id
        {
            get { return (int) this["id"]; }
            set { this["id"] = value; }
        }
        
        public string Name
        {
            get { return (string) this["name"]; }
            set { this["name"] = value; }
        }
    }
