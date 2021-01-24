    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged( [CallerMemberName] string propertyName = null )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
        protected bool Set<T>( ref T storage, T value, [CallerMemberName] string propertyName = null )
        {
            if ( Equals( storage, value ) ) return false;
            storage = value;
            OnPropertyChanged( propertyName );
            return true;
        }
        string _tags;
        bool _untagged;
        public string Tags
        {
            get => _tags; set
            {
                if ( Set( ref _tags, value ) )
                {
                    OnPropertyChanged( nameof( UntaggedEnabled ) );
                }
            }
        }
        public bool Untagged { get => _untagged; set => Set( ref _untagged, value ); }
        public bool UntaggedEnabled => string.IsNullOrWhiteSpace( Tags );
    }
