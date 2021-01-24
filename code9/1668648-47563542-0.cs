         foreach (Control c in Page.Form.Controls.OfType<RadioButtonList>())
            {
                if (c.ID.Contains("id"))
                {
                   // string FullID = c.ID.ToString();
                    var radioButtonList = c as RadioButtonList; 
                    var selectedValue = radioButtonList.SelectedValue;
                }
            }
