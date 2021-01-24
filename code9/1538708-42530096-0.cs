    void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
    	string alert = tb_message.Text;
    	if (alert != null && tb_message.Text.Length>0) {
    		Dispatcher.BeginInvoke(
    			(Action)(() => MessageBox.Show(alert, "Alert", MessageBoxButton.OK)));
    	}
    }
