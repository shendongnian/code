    private void Form1_Deactivate(object sender, EventArgs e)
    {
        ((Form)sender).Activate();
        System.Diagnostics.Debug.WriteLine(this.ActiveControl.Name);
        //Change Input Language here..
        //Alt TAB to set focus to the application selected 5 milliseconds ago
        SendKeys.SendWait("%{TAB");
    }
