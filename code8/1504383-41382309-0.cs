    namespace ViewModel
    {
        public class VMText : INotifyPropertyChanged
        {
    		public VMText(View.Editor editor)
            {
                _code = new Model.Text();
                this.editor = editor; 
            }
    	
    		public List<string> Code
            {            
                get
                {
                    return new List<string>(_code.Code.Split('\n'));
                }
                set
                {
                    _code.Code = System.String.Join("\n", value.ToArray());
    				NotifyPropertyChanged("Code");
                }
            }
    		
    		private void NotifyPropertyChanged(String propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    	
    		public event PropertyChangedEventHandler PropertyChanged;
    		
            private Model.Text _code;
    		
            private View.Editor editor;
        }
    }
