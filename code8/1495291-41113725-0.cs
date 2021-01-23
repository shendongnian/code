    public class Push
    {
        public string application_name { get; set; }
        public string body { get; set; }
        public int client_version { get; set; }
        public bool dismissable { get; set; }
        public bool has_root { get; set; }
        public string icon { get; set; }
        public string notification_id { get; set; }
        public object notification_tag { get; set; }
        public string package_name { get; set; }
        public string source_device_iden { get; set; }
        public string source_user_iden { get; set; }
        public string title { get; set; }
        public string type { get; set; }
    }
    
    public class RootObject
    {
        public Push push { get; set; }
        public string type { get; set; }
    }
