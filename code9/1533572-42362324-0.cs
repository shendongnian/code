    public void Include(Button button)
    {
        button.Click += (s, e)
            => button.Text = $"{button.Text}";
    }
