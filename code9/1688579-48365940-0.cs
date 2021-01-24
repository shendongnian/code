      private Form1 mainForm;
      public Control(Form1 form)
      {
        mainForm = form;
      }
      public bool ControlProject()
      {
        if (mainForm.rBtn101.Checked == false && mainForm.rBtn102.Checked == false && mainForm.rBtn103.Checked == false && mainForm.rBtn104.Checked == false && mainForm.rBtn206.Checked == false && mainForm.rBtn306.Checked == false)
          return false;
        if ((String.IsNullOrWhiteSpace(mainForm.textBoxProjectname.Text)) || (String.IsNullOrWhiteSpace(mainForm.textBoxClient.Text)) || (String.IsNullOrWhiteSpace(mainForm.textBoxProjectnr.Text))
          return false;
        return true;
      }
    }
