    private void buttonSave_Click(object sender, EventArgs e) {
      Process[] processes = Process.GetProcessesByName("WINWORD");// Kill Word Process
      ProcessForm processForm = new ProcessForm();
      Validation validateForm = new Validation();
      if (validateForm.Validate(this) ) { //Call to method 1
        processForm.CreateDocument();//Call to method 2 only if indicated by method 1      
      }             
    }
