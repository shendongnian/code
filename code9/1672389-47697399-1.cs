    private void buttonSearch_Click(object sender, EventArgs e)
    {
        var counter = 0;
        for (int i = 0; i < this.listBoxAddedIntegers.Items.Count; i++)
        {
            var item = this.listBoxAddedIntegers.Items[i];
            if (string.Equals(item.ToString(), this.textBoxSearch.Text, StringComparison.InvariantCultureIgnoreCase))
            {
                this.listBoxAddedIntegers.SelectedItems.Add(item);
                counter++;
            }
        }
        if (counter == 0)
        {
            MessageBox.Show($"No matches for {this.textBoxSearch.Text} found!", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            MessageBox.Show($"{counter} items found for {this.textBoxSearch.Text}!", "Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
