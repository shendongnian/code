    private void dynamicButton_Click(object sender, EventArgs e)
    {
        string path = "../../text.txt";
        var lines = File.ReadLines(path).ToArray();
        var found = false;
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains(dynamicTextBox.Text))
            {
                label1.Text = i + 1 + "";
                found = true;
            }
        }
        if (!found)
            label1.Text = "Not Found";
    }
