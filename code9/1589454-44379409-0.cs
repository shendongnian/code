     c.SetOnCheckedChangeListener(null);
                t.Text = Item.Name;
                c.Checked = Item.Checked;
                c.CheckedChange += (s, e) => 
                {
                    CheckBox checkBox = (CheckBox)s;
                    if (checkBox.Checked)
                        Item.Checked = true;
                    else
                        Item.Checked = false;
                };
