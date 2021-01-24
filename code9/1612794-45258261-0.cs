    private void EnabledButtons(List<Button> listButton, bool enabled)
    {
       foreach (Button btn in listButton)
       {
           foreach (Control ctrl in btn.Controls)
           {
               ctrl.Enabled = true;
           }
       }            
    } 
