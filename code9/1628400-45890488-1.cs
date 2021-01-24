        #region properties
    
        public ObservableCollection<Box> Boxes { get; } = new ObservableCollection<Box>();
    
        #endregion
    
        #region constructors
    
        public DrawBoxViewModel()
        {
            Boxes.Add(new Box() { Data = "hello!", LeftCanvas = 0, TopCanvas = 200 });
        }
    
        #endregion
