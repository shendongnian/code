    private void button1_Click(object sender, EventArgs e)
    {
        richTextBox1.AppendText(addText.returnText());
        // OR
        addData(addText.returnText());
    }
    public static string returnText()
    {
        string s = "test test;";
        return s;
    }
