    protected sealed override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    
        MyOnLoad(e);
    }
    protected virtual void MyOnLoad(EventArgs e)
    {
        // FormA onload
    }
