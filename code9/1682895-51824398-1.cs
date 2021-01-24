    bool pushStarted;
    protected void YourMethod()
    {
        pushStarted = true;
        await Navigation.PushAsync(myPage);
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        if(pushStarted)
        {
            pushStarted = false;
            foreach(var temp in myModel)
            {
                 //do bla bla
            }
        }
    }
