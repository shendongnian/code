    private void Microsoft_CheckStateChanged(object sender, EventArgs e)
    {
      if (comboBox_Copy.Visible != True)
      {
          comboBox_Copy.Visible = True;
      }
      else
      {
          comboBox_Copy.Visible = False;
      }
    }
