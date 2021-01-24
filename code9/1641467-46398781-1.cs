     protected void MyButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem  item in MyListView.Items)
                    {
                        
                        var ctrl = (HtmlContainerControl)item.FindControl("area");
                        ctrl.Attributes["style"] = "background-color:LightSkyBlue; color:Black; padding:0px;";
                  
        
                    }
        }
