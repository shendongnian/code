    string price = Request.QueryString["price"];                           
    string[] priceList = price.Split('|');                                  
    foreach (string p in priceList)                                               
    {                                                                            
        if (chkList.Items.FindByText(p) != null)                                  
        {                                      
              chkList.Items.FindByText(p).Selected = true;                        
        }                                                                           
    }                                                                       
