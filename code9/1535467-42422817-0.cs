    public class App: Application{
      public App(){
        MainPage = new NavigationPage(new ButtonPage());
      }
    ...
    }
    
    public class ButtonPage : ContentPage{
    ...
      async void OnButtonClicked(object sender, EventArgs args){
         await Navigation.PushModalAsync(new MenuPage());
      }
    }
