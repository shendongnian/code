    public class ObjectConfig
    {
        private bool bEnable;
        private int iArea;
        int max = 50;
        int min = 10;
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
                if (value < min)
                {
                    iArea = min;
                }
                else if (value > max)
                {
                    iArea = max;
                }
                else
                {
                    iArea = value;
                }
            }
        }
    }
