    [Serializable]
    public class SPoint
    {
        public int  PointColor { get; set; }
        public double XValue { get; set; }
        public double YValue { get; set; }
        public string Name { get; set; }
        public SPoint()        {        }
        public SPoint(int c, double xv, double yv,  string n)
        {
            PointColor = c; XValue = xv; YValue = yv; Name = n;
        }
        static public SPoint FromDataPoint(DataPoint dp)
        {
            return new SPoint(dp.Color.ToArgb(), dp.XValue, dp.YValues[0], dp.Name);
        }
        static public DataPoint FromSPoint(SPoint sp)
        {
            DataPoint dp = new DataPoint(sp.XValue, sp.YValue);
            dp.Color = Color.FromArgb(sp.PointColor);
            dp.Name = sp.Name;
            return dp;
        }
    }
    
