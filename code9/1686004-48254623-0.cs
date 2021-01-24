    public class MyViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
    
        public MyViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    
        public async Task SomeMethod()
        {
            await _navigationService.Navigate<NextViewModel, MyObject>(new MyObject());
        }
    }
    
    public class NextViewModel : MvxViewModel<MyObject>
    {
        private MyObject _myObject;
    
        public override void Prepare(MyObject parameter)
        {
            // receive and store the parameter here
            _myObject = parameter;
        }
    }
