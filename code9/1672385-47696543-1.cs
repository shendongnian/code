    private void buttonSearch_Click(object sender, EventArgs e)
        {
            listBoxAddedIntegers.SelectedItems.Clear();
    		
    		var itemsFound = listBoxAddedIntegers.Items.Where(i=>i.ToString().ToLower().Contains(textBoxSearch.Text.ToLower())).ToList();
    		
    		if(itemsFound == null)
    		{
    			MessageBox.Show("No matches found.");
    		}
    		else
    		{
    			MessageBox.Show("Found " + itemsFound.Count + " matches.");
    		}
    		
    	}
