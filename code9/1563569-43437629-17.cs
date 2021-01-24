    private void MouseNotMove3Seconds()
    {
        var button1 = new Button
        {
            Location = new Point(_oldMousePosition.X + Cursor.Size.Width, _oldMousePosition.Y),
            Text = "B"
        };
        Controls.Add(button1);
        var button2 = new Button
        {
            Location = new Point(_oldMousePosition.X - button1.Width / 2, _oldMousePosition.Y + Cursor.Size.Height),//I cheated a little bit here, but as the buttons are all the same...
            Text = "C"
        }; 
        Controls.Add(button2);
        var button3 = new Button
        {
            Location = new Point(_oldMousePosition.X - (int)(button1.Width * 1.5), _oldMousePosition.Y),
            Text = "D"
        };
        Controls.Add(button3);
        var button4 = new Button
        {
            Location = new Point(_oldMousePosition.X - button1.Width / 2, _oldMousePosition.Y - (int)(button1.Height * 1.5)),
            Text = "A"
        };
        Controls.Add(button4);
        button1.MouseHover += ButtonHovered;
        button2.MouseHover += ButtonHovered;
        button3.MouseHover += ButtonHovered;
        button4.MouseHover += ButtonHovered;
    }
