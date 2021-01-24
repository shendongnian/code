     foreach (ListItem li in CheckBoxList1.Items)
                {
                    if (li.Selected == true)
                    {
                      System.Diagnostics.Debug.WriteLine(li.value);
                    }
                }
