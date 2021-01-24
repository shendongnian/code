     private void bgwCustomIO_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (dio == null || string.IsNullOrEmpty(dio.uceMinHour.Text))
            {
                return;
            }
           MessageBox.Show(dio.uceMinHour.Text); // Show Combobox Value
        }
