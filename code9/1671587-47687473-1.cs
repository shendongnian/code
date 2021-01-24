    public async Task Login(string PhoneNumber, string Password)
    {
       AMethodException= null;  
       LoginObject login = await LoginServices.Login(PhoneNumber, Password, Token);
            if (login.IsOk)
            {
                // Move to next activity 
            }
            else
            {
                Toast.MakeText(this, "Login Error", ToastLength.Short).Show();
                AMethodException+= new AMethodExceptionHandler(Import_AMethodException);
            }
    }
