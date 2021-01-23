    public class MyViewModel
    {
        public ObservableCollectionRange<KeyValuePair<double, double>> Power { get; set; }
        public ObservableCollectionRange<KeyValuePair<double, double>> PowerAvg { get; set; }
        public MyViewModel()
        {
            Power = new ObservableCollectionRange<KeyValuePair<double, double>>();
            PowerAvg = new ObservableCollectionRange<KeyValuePair<double, double>>();
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
        public void AddRange(IEnumerable<KeyValuePair<double, double>> items)
        {
            Power.AddRange(items);
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
