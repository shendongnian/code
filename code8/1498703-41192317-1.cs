    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.F1:
                F1Pressed = true;
                break;
            case Keys.Left:
                if (F1Pressed)
                {
                    // draw dot with border
                }
                else
                {
                    // draw dot without border
                }
                break;
            case Keys.Right:
                if (F1Pressed)
                // and so on
        }
    }
