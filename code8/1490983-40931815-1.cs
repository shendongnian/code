    public class MyViewModel
    {
        public ObservableCollection<KeyValuePair<double, double>> Power { get; set; }
        public ObservableCollection<KeyValuePair<double, double>> PowerAvg { get; set; }
        public MyViewModel()
        {
            Power = new ObservableCollection<KeyValuePair<double, double>>();
            PowerAvg = new ObservableCollection<KeyValuePair<double, double>>();
        }
        public void Add(double x, double y)
        {
            Power.Add(new KeyValuePair<double, double>(x, y));
            double xmin = Power.Min(kvp => kvp.Key);
            double xmax = Power.Max(kvp => kvp.Key);
            double ymin = Power.Min(kvp => kvp.Value);
            double ymax = Power.Max(kvp => kvp.Value);
            double yavg = Power.Average(kvp => kvp.Value);
            PowerAvg.Clear(); 
            PowerAvg.Add(new KeyValuePair<double, double>(xmin, yavg));
            PowerAvg.Add(new KeyValuePair<double, double>(xmax, yavg));
        }
    }
