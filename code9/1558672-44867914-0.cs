    public Command RegisterCommand
            {
                get
                {
                    return new Command(async () =>
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new RegisterNewUser());
                    });
    
                }
            }
