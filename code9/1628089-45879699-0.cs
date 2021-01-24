    public class MyViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public MyViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        
        public override void Prepare()
        {
            //Do anything before navigating to the view
        }
    
        public async Task SomeMethod()
        {
            _navigationService.Navigate<NextViewModel, MyObject>(new MyObject());
        }
    }
    
    public class NextViewModel : MvxViewModel<MyObject>
    {
        public override void Prepare(MyObject parameter)
        {
            //Do anything before navigating to the view
            //Save the parameter to a property if you want to use it later
        }
        
        public override async Task Initialize()
        {
            //Do heavy work and data loading here
        }
    }
