    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    namespace CustomListBox
    {
        public class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] String propName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
        public class ThingViewModel : ViewModelBase
        {
            #region Name Property
            private String _name = "";
            public String Name
            {
                get { return _name; }
                set
                {
                    if (value != _name)
                    {
                        _name = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion Name Property
        }
        public class MainViewModel : ViewModelBase
        {
            #region Things Property
            private ObservableCollection<ThingViewModel> _things = new ObservableCollection<ThingViewModel>();
            public ObservableCollection<ThingViewModel> Things
            {
                get { return _things; }
                set
                {
                    if (value != _things)
                    {
                        _things = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion Things Property
            #region Stuff Property
            private ObservableCollection<object> _stuff = new ObservableCollection<object>();
            public ObservableCollection<object> Stuff
            {
                get { return _stuff; }
                set
                {
                    if (value != _stuff)
                    {
                        _stuff = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion Stuff Property
        }
    }
