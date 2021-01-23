    namespace WPFModel
    {
        public class Test : INotifyPropertyChanged
        {
            public ICommand DrawTextCommand { get; private set; }
            public event PropertyChangedEventHandler PropertyChanged;
            private string value1;
            public string TextBoxName
            {
                get { return value1; }
                set
                {
                    value1 = value;
                    RaisePropertyChanged("TextBoxName");
                }
            }
            public Test()
            {
                this.DrawTextCommand = new RelayCommand(DrawText);
            }
            protected void RaisePropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            public void Drawtext()
            {
                TextBoxName = "Textbox text";
            }
        }
    }
