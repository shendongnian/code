    User getUserFromDB()
    {
         //operate with db.
    }
    //navigate to another page and pass the data.
    private async void Button_Clicked(object sender, EventArgs e)
    {
         await Navigation.PushAsync(new MainPage()
         {
             BindingContext = getUserFromDB() 
         });
    }
