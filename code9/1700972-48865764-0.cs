    foreach(var control in yourPanel.Controls)
    { 
       try
       { 
          var radioButtonList = (RadioButtonList)control; 
          
          foreach(var item in radioButtonList.Items)
          {
             // something like 
             var selected = item.Selected;
             // or whatever code fits your needs
          }
       }
       catch
       {
         continue;
       }
    }
