    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace Player
    {
        public class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        public class MainViewModel : ViewModelBase
        {
            #region Player Property
            private PlayerViewModel _player = default(PlayerViewModel);
            public PlayerViewModel Player
            {
                get { return _player; }
                set
                {
                    if (value != _player)
                    {
                        _player = value;
                        OnPropertyChanged(nameof(Player));
                    }
                }
            }
            #endregion Player Property
            private ObservableCollection<String> _events = new ObservableCollection<string>();
            public ObservableCollection<String> Events
            {
                get { return _events; }
                set
                {
                    if (value != _events)
                    {
                        _events = value;
                        OnPropertyChanged(nameof(Events));
                    }
                }
            }
            #region Event Methods
            //  This is a BIG guess as to what you're trying to do.
            public void AddGreeting()
            {
                //  Player is "in scope" because Player is a property of this class. 
                if (Player == null)
                {
                    throw new Exception("Player is null. You can't greet a player who's not there.");
                }
                Events.Add(String.Format("\"Greetings {0}. What can I do for you today?\"", Player.Name));
            }
            #endregion Event Methods
        }
        public class PlayerViewModel : ViewModelBase
        {
            private String _name = default(String);
            public String Name
            {
                get { return _name; }
                set
                {
                    if (value != _name)
                    {
                        _name = value;
                        OnPropertyChanged(nameof(Name));
                    }
                }
            }
        }
    }
