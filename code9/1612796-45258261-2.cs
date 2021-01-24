    private void EnabledButtons(List<Button> listButton, int count)
    {
       foreach (Button btn in listButton)
       {
           btn.Enabled = false;
       }
       // or
       for (int i = 0; i < count; i++)
       {
           listButton[i].Enabled = false;
       }            
    } 
