     private void usingmltBtn_Click(object sender, RoutedEventArgs e)
            {
        
                if (RadioButton.Checked == true)
                {
                    RadioButton.Checked = false;
                    i2cerrRec.Visibility = Visibility.Collapsed;
                    i2cerrTxt.Visibility = Visibility.Collapsed;
                    mltI2Cnck = 0;
        
                }
                else if (RadioButton.Checked == false)
                {
                    RadioButton.Checked = true;
                    mlttempLbl.Text = "N/C";
                }
              }
