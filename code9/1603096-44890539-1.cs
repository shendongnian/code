    private void DrawButtons()
    {
        for (int i = 0; i < 90; i++)
        {
            Button button = new Button();
            ...
            button.Anchor = AnchorStyles.Left;//Add this also
            ...
        }
        panel4.AutoScroll = true;
    }
