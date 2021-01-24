    public class MainPage : ContentPage
    {
         protected override void OnAppearing()
         {
             base.OnAppearing();
             MyEntry.TextChanged += MyEntry_TextChanged;
         }
         
         protected override void OnDisappearing()
         {
             base.OnDisappearing();
             MyEntry.TextChanged -= MyEntry_TextChanged;
         }
    }
