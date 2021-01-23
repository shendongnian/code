    public class ViewModel
    {       
        private double _logoScaleValue;
        public double LogoScaleValue 
        { 
            get{return _logoScaleValue; }
            set
               {
                 _logoScaleValue = value;
                 SetLogoSize(value);
                }
        }
    
    
        public CompositeCommand SetLogoSizeCommand { get; set; }
    
        public ViewModel()
        {
            SetLogoSizeCommand = new CompositeCommand();
            SetLogoSizeCommand.RegisterCommand(new DelegateCommand<Double?>(SetLogoSize)); 
        }
    
    
        private void SetLogoSize(Double? argument)
        {
    
        }
    
    }
