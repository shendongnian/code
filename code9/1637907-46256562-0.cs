    private void rb_point1_CheckedChanged(object sender, EventArgs e)
    {
        ReadLineAndDisplayText("point01:");
    }
    private void ReadLineAndDisplayText(string lineStart)
    {
        string line;
        StreamReader file = new StreamReader(ccpath);
        while ((line = file.ReadLine()) != null)
        {
            if (line.StartsWith(lineStart))
            {
                message = (line.Split(':')[1]);
                txtb_message.Text = message;
            }
        }
    }
