    // set onclick listener here, by deleting some process
        button.Click += delegate {
            logonButtonClick();
        };
    public void logonButtonClick()
    {
        Toast.MakeText(this, "Proceed to Login ", ToastLength.Long).Show();
    }
