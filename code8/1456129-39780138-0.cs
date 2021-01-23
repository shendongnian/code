    class Program
    {
        static void Main(string[] args)
        {
            Value v = new Value();
            string output = v["hello"];
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
    public class Value
    {
        public string this[string nodeName]
        {
            get
            {
                ConfigurationManager.RefreshSection("appSettings");
                return ConfigurationManager.AppSettings[nodeName];
            }
            set
            {
                Configuration Config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
                Config.AppSettings.Settings[nodeName].Value = value;
                Config.AppSettings.SectionInformation.ForceSave = true;
                Config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
    }
