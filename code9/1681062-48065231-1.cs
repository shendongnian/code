    bool m_BackPressed = false; // It is because if user pres back button then it will remove ":" sign else it will never removed
    private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
    {
        m_BackPressed = (e.Key.ToString().Equals("Back")) ? true : false;
        if (e.Key.ToString().Equals("Back"))
        {
            e.Handled = false;
            return;
            m_BackPressed = true;
        }
        for (int i = 0; i < 10; i++)
        {
            if (e.Key.ToString() == string.Format("Number{0}", i) || e.Key.ToString() == string.Format("NumberPad{0}", i))
            {
                e.Handled = false;
                return;
            }
        }            
        e.Handled = true;
    }        
    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (MyTextBox.Text.Length == 2 && m_BackPressed != true)
        {
            MyTextBox.Text += ":";
            MyTextBox.Select(MyTextBox.Text.Length, 0);                
        }            
    }
