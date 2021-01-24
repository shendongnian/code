    public void button1_Click(object sender, EventArgs e)
    {
        var c = new Class1();
        var yourResult = c.GetDate(lastDay, firstDay);
        label7.Text = yourResult;
    }
    public int GetDate(DateTime lastDate, DateTime firstDate)
    {
        return (lastDate - firstDate).Days;
    }
