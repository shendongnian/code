    private void Button_Click(object sender, EventArgs e)
    {
       timer.Start();
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
        myListBox.Items.Add($"MyListItem{myListBox.Items.Count + 1}");
    }
