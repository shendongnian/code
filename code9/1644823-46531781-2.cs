    private void CRSWUNIQUE_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
       var swversionitem = CRSWUNIQUE.SelectedItem as swversion;
        if (swversionitem != null)
           // if (CRSWUNIQUE.SelectedItem != null)
        {            
            MessageBox.Show(swversionitem.SW_Version.ToString());
        }
    }
