    private void Remove_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
            
        if(btn.Tag is bool tag && tag == true)
        {
            DialogResult result = MessageBox.Show("Are you sure you want delete this user?  \n Deleting users may break workflows", "Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                 Delete(btn)            
            }
        }
        else
        {
             Delete(btn);
        }
     }
   
     private void Delete(Button btn)
     {
         int idx = RemoveButtons.IndexOf(btn);
         // Remove button
         RemoveButtons[idx].Dispose();
         RemoveButtons.RemoveAt(idx);
         // Remove textbox
         UsernameTextBoxes[idx + 1].Dispose();
         UsernameTextBoxes.RemoveAt(idx + 1);
         PasswordTextboxes[idx + 1].Dispose();
         PasswordTextboxes.RemoveAt(idx + 1);
         //Shift controls up - changes the location of the textboxes 
         for (int i = idx; i < RemoveButtons.Count; i++)
         {
             RemoveButtons[i].Top -= SpaceDelta;
             UsernameTextBoxes[i + 1].Top -= SpaceDelta;
             PasswordTextboxes[i + 1].Top -= SpaceDelta;
         }
         space -= SpaceDelta;
     }
