    private void excel_SheetActivate(object sh)
    {
        if(someControl.InvokeRequired)
        {
             someControl.Invoke(new Action(() => excel_SheetActivate(sh));
        }
        else
        {
            someControl.Text = //...
        }
    }
