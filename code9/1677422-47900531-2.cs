    private void Size_Click(object sender, System.EventArgs e)
    {
        List<string> vlist = new List<string>(textBox2.Text.Split('\n'));
        int currentLineNumber = vlist.Count;
        int targetLineNumber = Int32.Parse(textBox1.Text);
        if (targetLineNumber == currentLineNumber)
            return; //nothing to change
        else if (targetLineNumber > currentLineNumber) //increase number of line
        {
            for (int i = currentLineNumber; i < targetLineNumber; ++i)
                vlist.Add(vlist[(i - currentLineNumber) % currentLineNumber]);
        }
        else //reduce number of line
            vlist = vlist.GetRange(0, targetLineNumber);
        if (vlist.Count == 0)
            textBox2.Text = String.Empty;
        else
        {
            string result = vlist[0];
            for (int i = 1; i < targetLineNumber; ++i)
                result += String.Format("\n{0}", vlist[i]);
            textBox2.Text = result;
        }
    }
