    OpenFileDialog f = new OpenFileDialog();
    if (f.ShowDialog() == DialogResult.OK) {
        listBox1.Items.Clear();
        using (StreamReader sr = new StreamReader(f.OpenFile())) {
              string[] lines = sr.ReadToEnd().Split('\n');
              lines = lines.Skip(1).Reverse().Skip(1).Reverse().ToArray();
              listBox1.Items.AddRange(lines);
        }
    }
