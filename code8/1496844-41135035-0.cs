    public class MyPageViewModel : BindableBase
    {
        public MyPageViewModel()
        {
            MyCommand = new DelegateCommand<MyModel>( ExecuteMyCommand );
        }
        public ObservableCollection<MyModel> Collection { get; set; }
        public DelegateCommand<MyModel> MyCommand { get; }
        private void ExecuteMyCommand( MyModel model )
        {
            // Do Foo
        }
    }
