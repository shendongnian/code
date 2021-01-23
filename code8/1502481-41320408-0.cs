    private void Send_Click(object sender, RoutedEventArgs e)   
    {
        try
        {
            if(serial.IsOpen)
            {
                serial.Write(SendTB.Text + "\n");
                SendTB.Clear();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
