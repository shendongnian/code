    private void Cbx1_SelectedIndexChanged(object sender, EventArgs e)
    {
         cbx2.Items.Clear(); // Clear to add new retreived items
            
         if (cbx1.SelectedIndex != -1)
         {
             // Retrieve the items based on cbx1's selected item
             var items = Repository.RetreiveItems(cbx1.SelectedText);
             cbx2.Items.AddRange(items);
         }
    }
