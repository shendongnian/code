    private void button4_Click(object sender, EventArgs e)
    {
        listBox3.Items.Clear();
        var temp = listBox2.Items.Cast<string>().GroupBy(s => s);
        foreach(var g in temp)
        {
            int count = 0; foreach(string s in g) count++;
            listBox3.Items.Add(g.Key + ": " + count);
        }
    } 
