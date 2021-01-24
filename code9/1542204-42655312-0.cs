    private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (Keyboard.Modifiers == ModifierKeys.Alt)
        {
            string ctrlMod = "alt + " + e.SystemKey.ToString();
            Debug.WriteLine("Key is " + ctrlMod);
        }
    }   
----------
    private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        bool isAlt = Keyboard.Modifiers == ModifierKeys.Alt;
        bool isCtrl = Keyboard.Modifiers == ModifierKeys.Control;
        string ctrlMod = string.Empty;
        if (isAlt)
        {
            ctrlMod = "alt + " + e.SystemKey.ToString();
        }
        if (isCtrl)
        {
            ctrlMod = "ctrl + " + e.Key.ToString();
        }
        Debug.WriteLine("Key is " + ctrlMod);
    }
