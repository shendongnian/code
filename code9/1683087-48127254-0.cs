    private void ToggleButton(int button)
    {
        easyButton.ForeColor = Color.Black;
        mediumButton.ForeColor = Color.Black;
        hardButton.ForeColor = Color.Black;
    
        switch (button)
        {
            case 1: easyButton.ForeColor = Color.White; break;
            case 2: mediumButton.ForeColor = Color.White; break;
            case 3: hardButton.ForeColor = Color.White; break;
        }
    }
