                List<int> ls = new List<int>();
              
                {
                   
                    foreach (ListViewDataItem item in this.ListView2.Items)
                    {
                        if (item.ItemType == ListViewItemType.DataItem)
                        {
                            CheckBox chkRow = item.FindControl("CheckBox") as CheckBox;
    
                            if (chkRow.Checked)
                            {
                                int request = int.Parse((item.FindControl("FirstFind") as Label).Text.Trim());
                                
                                ls.Add(request);
                                
                                
                            }
                        }
                    }
                 
                   
                    repository.Approved(ls, newstat);
                    
