    bool invalid = false;
    foreach(Control ctr in this.Controls)
    {
      if(ctr is TextBox)
      {
        if(ctr.Text == string.empty)
          {
            invalid = true;
            break;
          }
      }
    }
    if(invalid)
    {
      MessageBox.Show("All fields are required!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
