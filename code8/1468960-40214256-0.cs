    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    namespace WpfApplication1
    {
        public class ObservableObject : INotifyPropertyChanged
        {
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void RaisePropertyChanged( [CallerMemberName] string propertyName = "" )
            {
                var handler = PropertyChanged;
                handler?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
            }
    
            protected bool SetProperty<T>( ref T backingField, T newValue, [CallerMemberName] string propertyName = "" )
            {
                return SetProperty<T>( ref backingField, newValue, EqualityComparer<T>.Default, propertyName );
            }
    
            protected bool SetProperty<T>( ref T backingField, T newValue, IEqualityComparer<T> comparer, [CallerMemberName] string propertyName = "" )
            {
                if ( comparer.Equals( backingField, newValue ) ) return false;
    
                backingField = newValue;
                RaisePropertyChanged( propertyName );
                return true;
            }
    
            protected bool SetProperty<T>( ref T backingField, T newValue, IComparer<T> comparer, [CallerMemberName] string propertyName = "" )
            {
                if ( comparer.Compare( backingField, newValue ) == 0 ) return false;
    
                backingField = newValue;
                RaisePropertyChanged( propertyName );
                return true;
            }
    
        }
    }
