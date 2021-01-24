    private void removeUc()
    {
         var forRemoval = new List<UserControl>();
         //Create removal list
         foreach (UserControl uc in fPanel.Controls)
         {
             forRemoval.Add(uc);
         }
         //remove from fpanel
         foreach (UserControl uc in forRemoval)
         {
             fPanel.Controls.Remove(uc);
         }
    }
