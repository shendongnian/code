    public class Assets : MVVM.ViewModel.ViewModelBase
    {
        public List<Asset> AllAssets { get; set; }
        private double col1Width;
        private double col2Width;
        public double Col1Width
        {
            get { return col1Width; }
            set { col1Width = value; OnPropertyChanged("Col1Width"); }
        }
        public double Col2Width
        {
            get { return col2Width; }
            set { col2Width = value; OnPropertyChanged("Col2Width"); }
        }
