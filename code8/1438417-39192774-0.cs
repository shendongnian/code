     void check_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            CheckBox senderCheck = sender as CheckBox;
            if (senderCheck.Checked)
            {
                foreach (var c in Container.Children)
                {
                    CheckBox check = c as CheckBox;
                    if (check != null)
                    {
                        if (radio.Id != senderCheck.Id)
                            check.Checked = true;
    
                    }
                }
            }
        }
