    private void sNameBtn_Click(object sender, EventArgs e)
    {
        summaryListBox.Items.Clear();
        summaryListBox.Items.AddRange(allCustomers.Select(x => x.Name).OrderBy(x => x));                 
    }
