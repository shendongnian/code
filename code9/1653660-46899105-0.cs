    private void AddItem()
    {
        if (!String.IsNullEmptyOrWhiteSpace(textBox1.Text))
        {
            var newItem = textBox1.Text.Trim();
            if (!List.Items.Contains(newItem))
            {
                List.Items.Add(newItem);
                // Alternative if you want the item at the top of the list instead of the bottom
                //List.Items.Insert(0, newItem);
                //Prepare to enter another item
                textBox1.Text = String.Empty;
                textBox1.Focus();
            }    
        }
    }
    private void Add_Click(object sender, EventArgs e)
    {
        AddItem();
    }
    Private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            AddItem();
        }
    }  
    private void Delete_Click(object sender, EventArgs e)
    {
        //Important to start at end and work toward the front, or you change later indices with earlier removals
        var selected = List.SelectedIndices.OrderBy(i => i * -1).ToList();
        // Remove every selected item using it's index
        foreach(int i in selected)
        {
            List.Items.RemoveAt(i);
        }
    }
