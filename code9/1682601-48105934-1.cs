     public class DetailButtonClass: INotifyPropertyChanged
                {
                    public event PropertyChangedEventHandler PropertyChanged;
                    private void NotifyPropertyChange(string propertyName)
                    {
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                        }
                    }           
                    string _DetailContent;
                    public string DetailContent
                    {
                        get
                        {
                            return _DetailContent;
                        }
                        set
                        {
                            _DetailContent = value;                    
                            NotifyPropertyChange("DetailContent");
                        }
                    }
                    string _DetailIndex;
                    public string DetailIndex
                    {
                        get
                        {
                            return _DetailIndex;
                        }
                        set
                        {
                            _DetailIndex = value;
                            NotifyPropertyChange("DetailIndex");
                        }
                    }           
                    CommandClass _ButtonClick;
                    public override CommandClass ButtonClick
                    {
                        get
                        {
                            return _ButtonClick;
                        }
                        set
                        {
                            _ButtonClick = value;
                            NotifyPropertyChange("ButtonClick");
                        }
                    }
     public class CommandClass : ICommand
            {            
                public event EventHandler CanExecuteChanged;
    
                public bool CanExecute(object parameter)
                {
                    return true;
                }
                public delegate void DelegateClickVoid(string index,string content);
                public DelegateClickVoid ClickVoid = null;            
                public void Execute(object parameter)
                {
                    string[] parameterArray = parameter.ToString().Split(",".ToArray());
                    ClickVoid?.Invoke(parameterArray[0], parameterArray[1]);
                }
    
            }
                }
