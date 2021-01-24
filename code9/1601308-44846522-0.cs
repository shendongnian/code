    protected override void OnNewIntent(Intent intent)
    {
        var listId = intent.GetStringExtra("ListID");
        ((App)App.Current).Redirect(listId);
    }
