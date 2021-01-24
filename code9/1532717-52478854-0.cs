    private void Form_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Up:
            case Keys.Down:
            case Keys.Left:
            case Keys.Right:
                e.IsInputKey = true;
                break;
        }
    }
