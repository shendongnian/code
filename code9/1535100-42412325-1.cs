    public class ObjectConfig
    {
        private bool bEnable;
        private int iArea;
        public bool enable
        {
            get { return bEnable; }
            set { bEnable = value; }
        }
        public int area
        {
            get { return iArea; }
            set
            {
                if (value < Properties.Settings.Default.AreaMin)
                {
                    iArea = Properties.Settings.Default.AreaMin;
                }
                else if (value > Properties.Settings.Default.AreaMax)
                {
                    iArea = Properties.Settings.Default.AreaMax;
                }
                else
                {
                    iArea = value;
                }
            }
        }
    }
