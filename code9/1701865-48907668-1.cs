    public class AutoCompleteViewModel : XLabs.Forms.Mvvm.ViewModel
    {
        private Color _placeholderColor = Color.White;
    
        public Color PlaceholderColor
        {
            get
            {
               return  _placeholderColor;
            }
            set
            {
                SetProperty(ref _placeholderColor, value);
            }
        }
    }
