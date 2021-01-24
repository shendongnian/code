        public class NotificationBase : INotifyPropertyChanged {
            protected void RaisePropertyChanged([CallerMemberName] string property = null)
            {
                var handler = PropertyChanged;
                if (handler != null) 
                { 
                    handler(this, new PropertyChangedEventArgs(property)); 
                }
            }
        }
        public class S3ObjectInfoHolder : NotificationBase
        {
            //  ...
        
