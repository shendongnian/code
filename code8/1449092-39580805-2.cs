    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    namespace DemoWPFApp1.ViewModels
    {
        public class BaseViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void OnPropertyChanged([CallerMemberName] string propName = null)
            {
                var e = PropertyChanged;
                if (e != null && propName != null)
                {
                    e.Invoke(this, new PropertyChangedEventArgs(propName));
                }
            }
        }
    }
