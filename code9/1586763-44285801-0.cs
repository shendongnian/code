            TabControl tc = TC_Fields;
            TabPage tpOld = tc.SelectedTab;
            TabPage tpNew = new TabPage();
            fields += 1;
            tpNew.Name = "Field_" + fields;
            tpNew.Text = "Field-" + fields;
            foreach (Control c in tpOld.Controls)
            {
                Control cNew = (Control) Activator.CreateInstance(c.GetType());
                PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(c);
                foreach (PropertyDescriptor entry in pdc)
                {
                    object val = entry.GetValue(c);
                    if (entry.Name == "Name")
                    {
                        val = (String) val + fields;
                    }
                    else if (entry.Name == "Location" || entry.Name == "Text" || entry.Name == "Bounds" || entry.Name == "Enabled" 
                        || entry.Name == "Visible" || entry.Name == "Checked" || entry.Name == "CheckState")
                    {
                        //Nothing to do, but do continue!
                    }
                    else if (entry.Name == "Controls")
                    {
                        Control.ControlCollection controllsInside = (Control.ControlCollection) val;
                        foreach (Control controllInside in controllsInside)
                        {
                            Control cNewInside = (Control) Activator.CreateInstance(controllInside.GetType());
                            PropertyDescriptorCollection pdcInside = TypeDescriptor.GetProperties(controllInside);
                            foreach (PropertyDescriptor entryInside in pdcInside)
                            {
                                object valInside = entryInside.GetValue(controllInside);
                                if (entryInside.Name == "Name")
                                {
                                    valInside = (String) valInside + fields;
                                }
                                else if (entryInside.Name == "Location" || entryInside.Name == "Text" || entryInside.Name == "Bounds" || entryInside.Name == "Enabled" 
                                    || entryInside.Name == "Visible" || entryInside.Name == "Checked" || entryInside.Name == "CheckState")
                                {
                                    //Nothing to do, but do continue!
                                }
                                else
                                {
                                    continue;
                                }
                                entryInside.SetValue(cNewInside, valInside);
                            }
                            cNew.Controls.Add(cNewInside);
                        }
                    }
                    else
                    {
                        continue;
                    }
                    entry.SetValue(cNew, val);
                }
                tpNew.Controls.Add(cNew);
            }
            tc.TabPages.Add(tpNew);
            TC_Fields.SelectedIndex = fields - 1;
