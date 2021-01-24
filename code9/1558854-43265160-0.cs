            protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {                               
                    Label asFoundTolerance = (Label)e.Item.FindControl("asFoundTolerance");
                    Label asLeftTolerance = (Label)e.Item.FindControl("asLeftTolerance");
                    Label asFoundPotential = (Label)e.Item.FindControl("asFoundPotential");
                    double foundPot = Convert.ToDouble(asFoundPotential.Text);                
                    if (foundPot < 305.5 || foundPot > 326.4)
                    {                    
                        asFoundTolerance.Text = "Out of Tolerance";
                        be4TestG.Checked = false;
                        be4TestB.Checked = true;
                    }
                    else
                    {
                        asFoundTolerance.Text = "In Tolerance";
                        be4TestG.Checked = true;
                        be4TestB.Checked = false;
                    }
                    Label asLeftPotential = (Label)e.Item.FindControl("asLeftPotential");
                    double leftPot = Convert.ToDouble(asLeftPotential.Text);
                    if (leftPot < 305.5 || leftPot > 326.4)
                    {
                        asLeftTolerance.Text = "Out of Tolerance";
                        aftTestG.Checked = false;
                        aftTestB.Checked = true;
                    }
                    else
                    {
                        asLeftTolerance.Text = "In Tolerance";
                        aftTestG.Checked = true;
                        aftTestB.Checked = false;
                    }
                }
            }
