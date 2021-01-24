        public class S3ObjectInfoHolder : NotificationBase
        {
            //  ...
            private bool _isSelected = false;
            public bool IsSelected {
               get { return _isSelected; }
               set {
                    if (_isSelected != value) {
                        _isSelected == value;
                        RaisePropertyChanged(nameof(IsSelected));
                    }
                }
            }
            //  ...
