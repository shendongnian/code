    protected void Service1_SelectedIndexChanged(object sender, EventArgs e)
            {
                CheckBoxList li = (CheckBoxList)sender;
                foreach (ListItem l in li.Items)
                {
                    if (l.Value == "2")
                    {
                        if (l.Selected)
                        {
                            Service1.Items[2].Enabled = false;
                        }
                        else
                        {
                            Service1.Items[2].Enabled = true;
                        }
    
                    }
                    else if (l.Value == "3")
                    {
                        if (l.Selected)
                        {
                            Service1.Items[1].Enabled = false;
                        }
                        else
                        {
                            Service1.Items[1].Enabled = true;
                        }
                    }
                }
            }
