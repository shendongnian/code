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
                        //  Change the player for all the existing events.
                        foreach (var e in Events)
                        {
                            e.Player = Player;
                        }
                    }
                }
            }
            #endregion Player Property
            private ObservableCollection<Event> _events = new ObservableCollection<Event>();
            public ObservableCollection<Event> Events
            {
                get { return _events; }
                private set
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
                Events.Add(new Event("\"Greetings {0}. What can I do for you today?\"", Player));
            }
            #endregion Event Methods
        }
        public class Employee : ViewModelBase
        {
            #region DisplayLtdOccupationId Property
            private bool _displayLtdOccupationId = default(bool);
            public bool DisplayLtdOccupationId
            {
                get { return _displayLtdOccupationId; }
                set
                {
                    if (value != _displayLtdOccupationId)
                    {
                        _displayLtdOccupationId = value;
                        OnPropertyChanged(nameof(DisplayLtdOccupationId));
                    }
                }
            }
            #endregion DisplayLtdOccupationId Property
        }
        public class Event : ViewModelBase
        {
            public Event(String format, PlayerViewModel player)
            {
                _format = format;
                Player = player;
            }
            private String _format = "";
            public String Message
            {
                get { return String.Format(_format, Player.Name); }
            }
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
                        //  When player changes, his name changes, so that 
                        //  means the value of Message will change. 
                        OnPropertyChanged(nameof(Message));
                        if (_player != null)
                        {
                            _player.PropertyChanged += _player_PropertyChanged;
                        }
                    }
                }
            }
            private void _player_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                switch (e.PropertyName)
                {
                    case nameof(PlayerViewModel.Name):
                        OnPropertyChanged(nameof(Message));
                        break;
                }
            }
            #endregion Player Property
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
