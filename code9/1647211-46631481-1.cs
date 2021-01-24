    private void button4_Click(object sender, EventArgs e)
    {
        listBox3.Items.Clear();
        var temp = listBox2.Items.Cast<string>().GroupBy(s => s);
        foreach(var g in temp)
            listBox3.Items.Add(g.Key + ": " + g.Count());
    } 
