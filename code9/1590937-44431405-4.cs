    public class MainViewModel : ViewModelBase
    {
        private int _fieldcount;
        private ObservableCollection<Models.Field> _fields;
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                _fieldcount = 100;
            }
            else
            {
                _fieldcount = 1000000;
            }
            Initialize();
        }
        private void Initialize()
        {
            var fieldquery = Enumerable.Range(1, _fieldcount).Select(e => new Models.Field { Name = $"Field {e}", Value = $"Value {e}", Flag = false, });
            Fields = new ObservableCollection<Models.Field>(fieldquery);
        }
        public ObservableCollection<Models.Field> Fields { get => _fields; set => Set(ref _fields, value); }
    }
