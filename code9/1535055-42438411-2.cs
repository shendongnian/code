    public class DimServicePoint
    {
        public virtual int ServicePointID { get; set; }
        public virtual int StartDayID { get; set; }
        public virtual int EndDayID { get; set; }
        public virtual int ServicePointKey { get; set; }
        public virtual ISet<DimServicePointMeter> ServicePointMeters { get; set; }
    }
    
    public class DimServicePointMeter
    {
        public virtual int ServicePointMeterID { get; set; }
        public virtual int ServicePointKey { get; set; }
    }
