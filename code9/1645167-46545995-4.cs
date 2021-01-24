    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //  C#7
        /*
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        */
        protected virtual void OnPropertyChanged(string propName)
        {
            var handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Project> _projects;
        public ObservableCollection<Project> Projects {
            get { return _projects; }
            set {
                 if (value != _projects) {
                     _projects = value;
                     OnPropertyChanged(nameof(Projects));
                }
            }
        }
        public void BuildData() {
            Projects = new ObservableCollection<Project>();
            //  do the rest of the stuff
        }
    }
