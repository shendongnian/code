    class Class1Model
    {
        // model properties
    }
    
    class Class1ViewModel
    {
        public Class1ViewModel(Class1Model model)
        {
            _Model = model;
        }
    
        private Class1Model _Model;
        public Class1Model Model { get { return _Model; } }
    
        // viewmodel specific extensions
    
        public string MyFormattedProperty => $"{Model.Height:###.00} x {Model.Width:###.00}"
    }
