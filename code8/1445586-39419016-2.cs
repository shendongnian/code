    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    namespace HollowEarth.MVVM
    {
        public class ViewModelBase : INotifyPropertyChanged
        {
            #region SetProperty
            protected virtual bool SetProperty<T>(ref T backingField, 
                T newValue, 
                [CallerMemberName] String propName = null)
            {
                if (EqualityComparer<T>.Default.Equals(backingField, newValue))
                {
    #if DEBUG
                    System.Diagnostics.Trace.WriteLine(
                        $"No change in {propName} == {backingField}");
    #endif
                    return false;
                }
    #if DEBUG
                System.Diagnostics.Trace.WriteLine(
                    $"Changing {propName} from {backingField} to {newValue}");
    #endif
                backingField = newValue;
                OnPropertyChanged(propName);
                return true;
            }
            #endregion SetProperty
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(
                [CallerMemberName] String propName = null)
            {
                PropertyChanged?.Invoke(this, 
                    new PropertyChangedEventArgs(propName));
            }
            #endregion INotifyPropertyChanged
        }
    }
