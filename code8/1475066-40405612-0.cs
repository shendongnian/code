    public class RofPoints : IComparable<RofPoints>
    {
        [DisplayName("X")]
        [Description("Punkte der X axis")]
        public int X { get; set; }
        [DisplayName("Y")]
        [Description("Punkte auf der Y Achse")]
        public int Y { get; set; }
        private double dx;
        [DisplayName("dX")]
        [Description("Punkte auf der X Achse mit double values")]
        public double dX
        {
            get
            {
                return dx;
            }
            set
            {
                dx = value;
            }
        }
        private double dy;
        [DisplayName("dY")]
        [Description("Punkte auf der Y Achse mit double values")]
        public double dY
        {
            get
            {
                return dy;
            }
            set
            {
                dy = value;
            }
        }
        
        public int CompareTo(RofPoints other)
        {
            //Here you must compare a RofPoints object to another
        }
    }
