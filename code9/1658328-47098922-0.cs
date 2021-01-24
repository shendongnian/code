    // Declare a public property
    public int CategoryId 
    { 
       set
       {
           // use the value keyword to get the value passed from the main page:
           if (string.IsNullOrEmpty(menuContent))
           {                
               menuContent = GenerateMenu(value, 1);  
               phMenu.Text = menuContent;             
           }
       }
    }
