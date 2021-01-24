    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            var vm1 = new MissionVM { Id = 1, Name = "111"};
            var vm2 = new MissionVM { Id = 2, Name = "222" };
            var vm3 = new MissionVM { Id = 3, Name = "333" };
            MissionVMs = new ObservableCollection<MissionVM> { vm1, vm2, vm3};
            MissionsToGive = new ObservableCollection<int> {1, 2, 3};
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<int> MissionsToGive { get; set; }
        public int SelectedMissionToGive { get; set; }
        public ObservableCollection<MissionVM> MissionVMs { get; set; }
    }
    public class MissionVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
