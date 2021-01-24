    private void CheckBoxOperations(Control parentControl)
                {
                    foreach (Control c in parentControl.Controls)
                    {
                        if (c is CheckBox)
                        {
                            if (((CheckBox)c).Checked)
                            {
                                //DoSomething
                            }
                        }
                        if (c.HasChildren)
                        {
                            CheckBoxOperations(c);
                        }
                    }
                }
    
    
         private void btnExecutedSelected_Click(object sender, EventArgs e)
            {
               CheckBoxOperations(this);
            }
