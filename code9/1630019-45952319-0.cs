    //When your processing starts
    this.Enabled = false;
    Form form = new YourForm();
    form.Show();
    Application.OpenForms[form.Name].Focus();
    Application.OpenForms[form.Name].TopMost = true;
    
    //When your processing finishes
    form.Close();
    this.Enabled = true;
    this.Focus();
