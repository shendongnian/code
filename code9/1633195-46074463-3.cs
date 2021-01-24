    OpenFileDialog f = new OpenFileDialog();
    if (f.ShowDialog() == DialogResult.OK) {
        listBox1.Items.Clear();
        List<string> lines = new List<string>();
        using (StreamReader sr = new StreamReader(f.OpenFile())) {
              string line;
              while ((line = sr.ReadLine()) != null) {
                    lines.Add(line); // add lines to list first
              }
        }
        string[] resultArray = lines.Skip(1).Reverse().Skip(1).Reverse().ToArray();
    //skip first one , reverse so last one is the first now, skip again and reverse again to get actual list
        listBox1.Items.Add(resultArray);
    }
