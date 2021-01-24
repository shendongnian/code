    using System;
    using System.ComponentModel;
    using System.Windows.Media;
    namespace GridItemAnswer
    {
        #region ViewModelBase Class
        public class ViewModelBase : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propName = null) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            #endregion INotifyPropertyChanged
        }
        #endregion ViewModelBase Class
        #region GridItemViewModel Class
        public class GridItemViewModel : ViewModelBase
        {
            #region LabelText Property
            private String _labelText = null;
            public String LabelText
            {
                get { return _labelText; }
                set
                {
                    if (value != _labelText)
                    {
                        _labelText = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion LabelText Property
            #region Path Property
            private String _path = null;
            public String Path
            {
                get { return _path; }
                set
                {
                    if (value != _path)
                    {
                        _path = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion Path Property
            #region ImageSource Property
            private ImageSource _imageSource = null;
            public ImageSource ImageSource
            {
                get { return _imageSource; }
                set
                {
                    if (value != _imageSource)
                    {
                        _imageSource = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion ImageSource Property
        }
        #endregion GridItemViewModel Class
    }
