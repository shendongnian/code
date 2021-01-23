    //DialogControl.cs
    bool _closed = false;
    DialogResult _result;
    DialogResult ShowModal()
    {
        this.Show();
        while(!_closed) Application.DoEvents();  //Infinite loop
        return _result;
    }
    public void OkButton_OnClick(EventArgs e, object sender)
    {
        _result = DialogResult.OK;
        _closed = true;
    }
    public void CancelButton_OnClick(EventArgs e, object sender)
    {
        _result = DialogResult.Cancel;
        _closed = true;
    }
        
