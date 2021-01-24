     void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e) 
     {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) 
          {            
              TextBox txt21 = (TextBox)e.Item.FindControl("txt21");
              RequiredFieldValidator rfv21 = (RequiredFieldValidator)e.Item.FindControl("rfv21");
              txt21.Attributes.Add("onclick", "txt21_onChange('" + txt21.ClientID + "','" + rfv21.ClientID + "'" )            
          }
     }    
