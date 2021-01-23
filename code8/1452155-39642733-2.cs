        private readonly Dictionary<CheckBox, double> mapping;
        public MainWindow()
        {
            InitializeComponent();
            mapping = new Dictionary<CheckBox, double>
            {
                {cbBean, 2d},
                {cbSpringMix, 2d}
                //...
            };
        }
        public double TotalOrderCost()
        {
            double foodCost = 0d;
            foreach (KeyValuePair<CheckBox, double> keyValuePair in mapping)
            {
                if (keyValuePair.Key.Checked)
                {
                    foodCost += keyValuePair.Value;
                }
            }
            return foodCost;
        }
