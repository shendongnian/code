    public class ViewModel_A : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        public ViewModel_A(IMvxNavigationService navigation)
        {
            _navigationService = navigationService;
        }
        
        public override async Task Initialize()
        {
            //Do heavy work and data loading here
        }
    
        public async Task SomeMethod()
        {
            var result = await _navigationService.Navigate<ViewModel_Values, MyObject, MyReturnObject>(new MyObject());
            //Do something with the result MyReturnObject that you get back
        }
    }
    
    public class ViewModel_Values : MvxViewModel<MyObject, MyReturnObject>
    {
        private readonly IMvxNavigationService _navigationService;
        public ViewModel_Values(IMvxNavigationService navigation)
        {
            _navigationService = navigationService;
        }
        
        public override void Prepare(MyObject parameter)
        {
            //Do anything before navigating to the view
            //Save the parameter to a property if you want to use it later
        }
        
        public override async Task Initialize()
        {
            //Do heavy work and data loading here
        }
        
        public async Task SomeMethodToClose()
        {
            // here you returned the value
            await _navigationService.Close(this, new MyReturnObject());
        }
    }
