    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    namespace VM
    {
        public class BaseViewModel : INotifyPropertyChanged
        {
            #region INPC
            public event PropertyChangedEventHandler PropertyChanged; 
            protected virtual void OnPropertyChanged([CallerMemberName] string prop = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
            #endregion
        }
    }
