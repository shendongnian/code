    private bool _slash = false;
    private void Window_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
    {
        if (e.Text == "/")
        {
            _slash = true;
            e.Handled = true;
            //...
        }
        else
        {
            _slash = false;
        }
    }
    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == System.Windows.Input.Key.Enter && _slash)
        {
            // "/" + ENTER was pressed...
        }
    }
