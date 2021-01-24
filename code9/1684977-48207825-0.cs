    private void Button1_Click(object sender, EventArgs e)
    {
        var values = new List<string>();
        if (checkBox1.Checked)
            values.Add("'T05A1.1'");
        if (checkBox2.Checked)
            values.Add("'C16D6.2'");
        if (checkBox3.Checked)
            values.Add("'F41E7.3'");
        // and so on
        String filterdata = string.Join(",", values);
        ...
    }
