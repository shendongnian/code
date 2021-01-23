    private void excel_SheetActivate(object activatedSheet)
    {
        if(someControl.InvokeRequired)
        {
             someControl.Invoke(new Action(() => excel_SheetActivate(activatedSheet));
        }
        else
        {
            someControl.Text = //...
        }
    }
