    private void btnRemoveManager_Click(object sender, RoutedEventArgs e)
        {
            if (lbxManagerDisplay.SelectedValue != null)
            {
                ManagerTBL selected = lbxManagerDisplay.SelectedValue as ManagerTBL;
                var removeManager = db.ManagerTBLs.SingleOrDefault(x => x.ManagerName == selected.ManagerName); //returns a single item.
   
               if (removeManager != null)
                {
                  db.ManagerTBLs.Remove(removeManager );
                  db.SaveChanges();
                }    
                   
                // Repeat the on window loaded method to refresh the grids
                Window_Loaded(sender, e);
    
            }
    
            else
            {
                MessageBox.Show("Please select a team from the league");
            }
        }
  
