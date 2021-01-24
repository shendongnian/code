    public class MyViewModel
    {
        public ObservableCollection<DataPoint> Data1 { get; set; }
        public ObservableCollection<DataPoint> Data2 { get; set; }
    
        public MyViewModel()
        {
            Data1 = new ObservableCollection<DataPoint>();
            Data2 = new ObservableCollection<DataPoint>();
    
            double pi = Math.PI;
            double a = pi / 4; // rotation angle
            double fw = 5; // wave frequency
            double fs = 100 * fw; // sampling rate
            double te = 1; // end time
            int size = (int)(fs * te); 
    
            // do your calculations
            var x1 = Enumerable.Range(0, size).Select(p => p / fs).ToArray();
            var y1 = x1.Select(p => Math.Sin(2*pi*fw*p)).ToArray();
    
            //populate your Model (original data)
            for (int i = 0; i < y1.Length; i++)
                Data1.Add(new DataPoint(x1[i], y1[i]));
    
            // transform original data
            var x2 = Data1.Select(p => p.X * Math.Cos(a) - p.Y * Math.Sin(a)).ToArray();
            var y2 = Data1.Select(p => p.X * Math.Sin(a) + p.Y * Math.Cos(a)).ToArray();
    
            // populate your Model (transformed data)
            for (int i = 0; i < y2.Length; i++)
                Data2.Add(new DataPoint(x2[i], y2[i]));
        }
    }
