    private void Form1_Load(object sender, EventArgs e)
    {
        List<string> lines = new List<string>();
        using (StreamReader file = new StreamReader("filepath"))
        {
            string line;
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }
        comboBox1.DataSource = lines;
    }
