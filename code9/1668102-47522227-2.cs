    //If Page is with Master Page Add 
      Control form = Master.FindControl("form1");
      Control content1 = form.FindControl("ContentPlaceHolder1"); 
      //and Replace this with content1 in loop. Same with LINQ version
       
      foreach (Control c in this.Controls)
     // Here this refers to Page Controls. If page is with MasterPage then first 
     //we need to go to parent container.
     //Let's say all your controls are inside of Panel, then you need to use 
     //panel1.Controls where panel1 is ID of Panel.
                {
                if (c is RadioButtonList)
                {
                    if (c.ID.Contains("id"))
                    {
                        string FullID = c.ID.ToString();
                    }
                }
                }
