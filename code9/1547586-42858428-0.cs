    private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
    {
        if (e.TabPage == tabPage)
        {
           if (!TabSelectingAllowed)
               e.Cancel = true;
        }
    }
