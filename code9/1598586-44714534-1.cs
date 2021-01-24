    // set onclick listener here, by deleting some process
        button.Click += delegate {
            loginButtonClick();
        };
    public void loginButtonClick()
    {
        Toast.MakeText(this, "Proceed to Login ", ToastLength.Long).Show();
    }
