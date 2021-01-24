       string t1;
                    
                
                    t1 = lstBoxAddedTours.SelectedItem.ToString();
                    int i = 0;
                    while (i < lbxcityTours.Items.Count)
                    {
                        
                        if (lbxcityTours.Items[i].Text == t1)
                        {
                            work.Text = i.ToString();                         
                            lstBoxAddedTours.Items.Remove(lstBoxAddedTours.SelectedItem);
                            lbxcityTours.Items[i].Value = "0";                     
                            lstBoxAddedTours.SelectedIndex.Equals(null);
                           
                            lbxcityTours.SelectedIndex.Equals(null);
    
                            break;
                        }
                        i +=1;
                    }
                
