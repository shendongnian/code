    foreach(string item in form.Keys){
       if (actCount > 1)
       {
           for (int i = 1; i < actCount; i++)
           {
               if (frm["AccountNumberTextBox" + i].Substring(0, 3) != "165")
               {   
                    
                    ViewBag.SaveError = "Invalid customer account number detected. Account number must start with 165 but not " + frm["txtAccountNumberField" + i].Substring(0, 3);
    
                    ViewBag.ValidationStatus = false;
    
                    
                    lst.Add(frm["AccountNumberTextBox" + i]);
    
                    ViewBag.ListOfAccounts = lst;
                    this.redisplay();
    
                    
                }
            }
        }
    }
    return View(customerModel);
