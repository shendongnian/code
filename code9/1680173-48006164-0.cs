    private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Down:
            case Keys.Up:
                e.IsInputKey = true;
                break;
        }
    }
