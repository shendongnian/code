    private void CRSWUNIQUE_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        swversionitem = CRSWUNIQUE.SelectedItem as swversion;
        if (item != null)
           // if (CRSWUNIQUE.SelectedItem != null)
        {            
            MessageBox.Show(item.SW_Version.ToString());
        }
    }
