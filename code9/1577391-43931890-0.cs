    public class MyPageViewModel : BindableBase
    {
        public MyPageViewModel()
        {
            OptionsToChoose = new ObservableRangeCollection<Tabbed>();
            SomeCommand = new DelegateCommand(OnSomeCommandExecuted);
        }
        public DelegateCommand SomeCommand { get; }
        public ObservableRangeCollection<Tabbed> OptionsToChoose { get; } 
        private void OnSomeCommandExecuted()
        {
            // get some updated data
            IEnumerable<Tabbed> foo = DoFoo();
            OptionsToChoose.ReplaceRange(foo);
        }
    }
