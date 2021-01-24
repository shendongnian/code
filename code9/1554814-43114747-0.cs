    void CreateButton(TabControl tc, string text, Action<object, EventArgs> click)
    {
        Button button = new Button();
        button.Width = 100;
        button.Height = 100;
        button.ForeColor = Color.Blue;
        button.Text = text;
        button.Click += click;
        tc.Controls.Add(button);
    }
