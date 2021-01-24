    using Helpers;
    using Model;
    using Prism.Commands;
    using Prism.Mvvm;
    using Services;
    using System.Collections.ObjectModel;
    using System.Linq;
    public class MainWindowViewModel : BindableBase
    {
        #region Fields
        private  PeopleService _peopleService;
        #endregion // Fields
        #region Constructors
        public MainWindowViewModel()
        {
            // we might use dependency injection instead
            _peopleService = new PeopleService();
            People = new ObservableCollection<Person>();
            LoadListCommand = new DelegateCommand(LoadList);
            LoadPersonDetailsCommand = new DelegateCommand(LoadPersonDetails, CanLoadPersonDetails)
                .ObservesProperty(() => CurrentPerson)
                .ObservesProperty(() => IsBusy);
        }
        #endregion // Constructors
        #region Properties
        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private Person _currentPerson;
        public Person CurrentPerson
        {
            get { return _currentPerson; }
            set { SetProperty(ref _currentPerson, value); }
        }
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
        public ObservableCollection<Person> People { get; private set; }
        #endregion // Properties
        #region Commands
        public DelegateCommand LoadListCommand { get; private set; }
        private async void LoadList()
        {
            // reset the collection
            People.Clear();
            var ids = await _peopleService.GetIds();
            var peopleListStub = ids.Select(i => new Person { Id = i, IsLoaded = false, Name = "No details" });
            People.AddRange(peopleListStub);
        }
        public DelegateCommand LoadPersonDetailsCommand { get; private set; }
        private bool CanLoadPersonDetails()
        {
            return ((CurrentPerson != null) && !IsBusy);
        }
        private async void LoadPersonDetails()
        {
            IsBusy = true;
            var personDTO = await _peopleService.GetPersonDetail(CurrentPerson.Id);
            var updatedPerson = personDTO.ToModel();
            updatedPerson.IsLoaded = true;
            var oldPersonIndex = People.IndexOf(CurrentPerson);
            People.RemoveAt(oldPersonIndex);
            People.Insert(oldPersonIndex, updatedPerson);
            CurrentPerson = updatedPerson;
            IsBusy = false;
        }
        #endregion // Commands
    }
