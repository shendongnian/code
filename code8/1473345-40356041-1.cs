    public class MyPagePageModel : FreshBasePageModel
    {
       public ICommand GoToMainPageCommand { get; private set; }
       
       public MyPagePageModel()
       {
          GoToMainPageCommand = new Command(GoToPage);
       }
    
       private async void GoToPage()
       {
          await CoreMethods.PushPageModel<MainPageModel>();
       }
    }
