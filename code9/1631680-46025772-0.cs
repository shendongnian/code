    private void minPanel_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left) return; //ensure user left-clicked
        int pointedValue = Min + e.X * (Max - Min) / Width;
        SelectedMin += pointedValue;
    }
