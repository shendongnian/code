    public class Value: INotifyPropertyChanged
        {
           public event PropertyChangedEventHandler PropertyChanged;
           protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
           {
              //this.VerifyPropertyName(propertyName);
    
              PropertyChangedEventHandler handler = this.PropertyChanged;
              if (handler != null)
              {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
               }
            }
