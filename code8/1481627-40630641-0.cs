    bool checkCancel = true;
    private void button2_Click(object sender, EventArgs e)
    {
        checkCancel = false;
        tabControl1.SelectTab("tabPage2");
    }
    private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
    {
        e.Cancel = checkCancel;
        checkCancel = true;
    }
