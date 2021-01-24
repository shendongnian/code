    private void Add_Click(object sender, EventArgs e)
    {
        // Since you do not want to add empty or null
        // strings check for it and skip adding if check fails
        if (!String.IsNullEmptyOrWhiteSpace(textBox1.Text)
        {
            // Good habit is to remove trailing and leading 
            // white space what Trim() method does
            List.Items.Insert(0, textBox1.Text.Trim());
        }
    }
    private void Delete_Click(object sender, EventArgs e)
    {
        // Get all selected items indices first
        var selectedIndices = List.SelectedIndices;
        // Remove every selected item using it's index
        foreach(int i in selectedIndices)
            List.Items.RemoveAt(i);
    }
