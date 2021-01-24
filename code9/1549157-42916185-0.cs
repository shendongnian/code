      private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e) 
        {
         string curItem = listBox1.SelectedItem.ToString(); 
         foreach( var path in fullFileName) 
          { 
          if (System.IO.Path.GetFileName(path).Equals(curItem, StringComparison.OrdinalIgnoreCase))
            {
            MessageBox.Show("Full path = " + path); 
            break; 
            }
         }
      }
