    private int _clickCounter = 0;
    private void testToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if(_clickCounter % 2 == 0)
        {
            Test();
        }
        else
        {
            ListViewCostumControl.lvnf.Items.Clear();
            textBox4.Enabled = false;
        }
        _clickCounter++;
    }
