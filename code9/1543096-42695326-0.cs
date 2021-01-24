    private void button_Click(object sender, EventArgs e)
    {
        string a = TreeView.SelectedNode.FullPath.ToString();
        string b = ":\\";
        string c = a.Insert(1, b);
        richTextBox1.LoadFile(c, RichTextBoxStreamType.PlainText);
    }
