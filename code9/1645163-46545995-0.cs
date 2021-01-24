    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        #endregion INotifyPropertyChanged
    }
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Project> _projects;
        public ObservableCollection<Project> Projects {
            get { return _projects; }
            set {
                 if (value != _projects) {
                     _projects = value;
                     OnPropertyChanged();
                }
            }
        }
        public void BuildData() {
            Projects = new ObservableCollection<Project>();
            //  do the rest of the stuff
        }
    }
