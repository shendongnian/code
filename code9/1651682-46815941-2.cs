    private int _clickCounter = 0;
    private void testToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if(_clickCounter % 2 == 0)
        {
            Test();
        }
        else
        {
            Clear();
        }
        _clickCounter++;
    }
    private void Test()
    {
        for (int i = 0; i < random.Next(20,1000); i++)
        {
            string rand = RandomString(200);
            ListViewCostumControl.lvnf.Items.Add(rand);
        }
        textBox4.Enabled = true;
        listv = ListViewCostumControl.lvnf.Items.Cast<ListViewItem>()
                             .Select(item => item.Text)
                             .ToList();      
    }
    private void Clear() //whatever you want to name it
    {
        ListViewCostumControl.lvnf.Items.Clear();
        textBox4.Enabled = false;      
    }
