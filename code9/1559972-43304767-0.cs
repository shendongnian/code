    public void closePopUp(string formName)
    {
        // No need to loop over all application OpenForms if you just want
        // to close this popup
        // for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
        // {
        //    string name = Application.OpenForms[i].Name; //for debugging only
        //    if (Application.OpenForms[i].Name == formName)
        //        Application.OpenForms[i].Close();
        //}           
        var mainForm = this.Tag as MainForm;
        this.Close();
        if(mainForm != null)
            mainForm.Activate();
    }
