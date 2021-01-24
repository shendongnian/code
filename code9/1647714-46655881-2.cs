    private void Microsoft_CheckStateChanged(object sender, EventArgs e)
    {
      var resultFromCheckBox = sender as CheckBox; // This line acts as a link between the check box (i.e. Microsoft) and this function so you can use resultFromCheckBox instead of Microsoft.      
      if (resultFromCheckBox.CheckState == CheckState.Checked)
      {
          comboBox_Copy.Visibility = System.Windows.Visibility.Visible; // Sets box to visible if checkbox is selected
      }
      else
      {
          comboBox_Copy.Visibility = System.Windows.Visibility.Hidden; // Sets to hidden in all other cases i.e. when it is not selected.
      }
    }
