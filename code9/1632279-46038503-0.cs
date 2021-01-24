       private void birthday_SelectedIndexChanged(object sender, EventArgs e) {
         // Previous is Enabled if and only if the selected item is not first one
         btnPrevious.Enabled = birthday.SelectedIndex > 0; 
         // btnNext is enabled if and only if
         //   1. birthday has items (not empty)
         //   2. An item selected
         //   3. The item is not the last one 
         btnNext.Enabled = birthday.SelectedIndex >= 0 && // an item selected
                           birthday.SelectedIndex < birthday.Items.Count - 1;
       }
