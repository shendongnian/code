    private void sNameBtn_Click(object sender, EventArgs e)
    {
        summaryListBox.Items.Clear();
        summaryListBox.Items.AddRange(allCustomers.OrderBy(x => x).Select(x => x.DisplayCustomers()));                 
    }
