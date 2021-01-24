    public class PersonViewModel(){
        public Person Person { get; set; }
    }
    public class MainViewModel(){
        public Club Club { get; set; }
        public ObservableCollection<PersonViewModel> PersonViewModels { get; set;}
        public PersonViewModel CurrentPersonViewModel { get; set; }
    }
