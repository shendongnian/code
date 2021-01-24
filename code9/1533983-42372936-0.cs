    private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.SystemKey == Key.F10 && (Keyboard.IsKeyDown(Key.LWin) || Keyboard.IsKeyDown(Key.RWin)))
        {
            Console.WriteLine("Succes!");
        }
    }
