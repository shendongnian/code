    private void comboBox1_Leave(object sender, EventArgs e)
    {
         string item = source.FirstOrDefault(x => x.StartsWith(comboBox1.Text));  
         //search string inside source of suggests and if there is a match get the first one
         if(!string.IsNullOrEmpty(item)) 
         {
              int index = comboBox1.Items.IndexOf(item); // find it inside combobox items
              comboBox1.SelectedIndex = index; // and select it
    
          }
    }
