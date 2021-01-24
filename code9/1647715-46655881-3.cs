    private void Microsoft_CheckStateChanged(object sender, EventArgs e)
    {
      if (comboBox_Copy.Visibility != System.Windows.Visibility.Visible)
      {
          comboBox_Copy.Visibility = System.Windows.Visibility.Visible;
      }
      else
      {
          comboBox_Copy.Visibility = System.Windows.Visibility.Hidden;
      }
    }
