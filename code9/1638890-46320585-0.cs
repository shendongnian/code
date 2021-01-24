    public bool GetFirstControl(Control ctrl)
        {
            foreach (Control ctrlItem in ctrl.Controls)
            {
                if (ctrlItem.HasChildren)
                {
                    if(GetFirstControl(ctrlItem))
                    {
                        return true;
                    }
                }
                else if (ctrlItem is Control && ctrlItem.CanFocus && ctrlItem.TabStop && ctrlItem.Enabled && ctrlItem.Visible && ctrlItem.Size.Width > 0)
                {
                    ctrlItem.Focus();
                    return true;
                }
            }
            return false;
        }
