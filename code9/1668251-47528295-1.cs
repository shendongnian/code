    public void updateTextBox(string newText)
    {
	    if (!Dispatcher.CheckAccess())
        {
		    Dispatcher.BeginInvoke((Action<string>)updateTextBox, newText);
            return;
        }
        textBox1.Text = newText;
    }
