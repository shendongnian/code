    private Action<int, Result, Intent> resultCallbackvalue;
    
    public void StartActivity(Intent intent, int requestCode, Action<int, Result, Intent> resultCallback)
    {
        this.resultCallbackvalue = resultCallback;
        StartActivityForResult(intent, requestCode);
    }
    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
        base.OnActivityResult(requestCode, resultCode, data);
        if (this.resultCallbackvalue != null)
    {
       this.resultCallbackvalue(requestCode, resultCode, data);
       this.resultCallbackvalue = null;
    }
    
