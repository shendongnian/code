    namespace ConfigTest.Configuration
{
    public class MyConfig : ConfigurationSection
    {
        private static JObject _props;
        private static FileSystemWatcher watcher;
        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get { return (string)this["path"]; }
            set { this["path"] = value; }
        }
        [ConfigurationProperty("watch", IsRequired = false)]
        public bool Watch
        {
            get { return (bool)this["watch"]; }
            set { this["watch"] = value; }
        }
        private static JObject GetValues(string path)
        {
            string data = File.ReadAllText(path);
            JObject j = JObject.Parse(data);
            return j;
        }
        public static T Read<T>(string path)
        {
            var token = _props.SelectToken(path);
            if (token == null)
                return default(T);
            return token.ToObject<T>();
        }
        public static void Load()
        {
            MyConfig section = (MyConfig)ConfigurationManager.GetSection("myConfig");
            string path = section.Path;
            LoadValues(path);
            if (section.Watch)
                FileSystemWatcher(path);
        }
        private static void LoadValues(string path)
        {
            JObject props = GetValues(path);
            _props = props;
        }
        private static void FileSystemWatcher(string path)
        {
            if (watcher != null)
                watcher.Dispose();
            watcher = new System.IO.FileSystemWatcher();
            watcher.Path = System.IO.Path.GetDirectoryName(path);
            watcher.Filter = System.IO.Path.GetFileName(path);
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            FileSystemWatcher watcher = (FileSystemWatcher)sender;
            watcher.EnableRaisingEvents = false;
            LoadValues(e.FullPath);
            watcher.EnableRaisingEvents = true;
        }
    }
