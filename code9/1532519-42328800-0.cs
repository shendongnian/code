    private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedTab == TabControl.TabPages[""])//
            {
                TabControl.Visible = false;
            }
            else
            {
                TabControl.Visible = true;
            }
        }
