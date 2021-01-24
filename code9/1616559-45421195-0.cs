    public class Alert //This is each alert
    {
        public string Name;
        public string Decription;
        ...
    }
    public class Alerts //This is group of all alert
    {
        public List<Alert> Alert;
        public Alerts()
        {
            Alert = new List<Alert>();
        }
    }
    public class Program
    {        
        public static Alerts LoadAlertsFromJson() //With this you can load alerts to other classes with Program.LoadAlertsFromJson();
        {
            string jsonString = loadYourStringHere;
            Alerts a = JsonUtility.FromJson<Alerts>(jsonString);
            return a;
        }
        public static void AddAlert(Alert alert)
        {
            Alerts alerts = LoadAlertsFromJson();
            alerts.Add(alert);
            SaveAlerts(alerts);
        }
        
        public static void SaveAlerts(Alerts alerts)
        {
            string jsonString = JsonUtility.ToJson(alerts);
            //write this string to your file
        }
    }
