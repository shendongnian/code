    protected override void OnPause()
    {
        base.OnPause();
        Log.Error(Tag, "OnPause");
    }
    protected override void OnResume()
    {
        base.OnResume();
        Log.Error(Tag, "OnResume");
    }
    protected override void OnSaveInstanceState(Bundle outState)
    {
        base.OnSaveInstanceState(outState);
        Log.Error(Tag, "OnSaveInstanceState");
    }
    protected override void OnRestoreInstanceState(Bundle savedInstanceState)
    {
        base.OnRestoreInstanceState(savedInstanceState);
        Log.Error(Tag, "OnRestoreInstanceState");
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        Log.Error(Tag, "OnDestroy");
    }
    ......
