    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using App1.Annotations;
    
    namespace App1
    {
        public class Ausstattung : INotifyPropertyChanged
        {
            private string _textValue;
            public string TextValue
            {
                get => _textValue;
                set
                {
                    _textValue = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
