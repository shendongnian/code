    textBox2.Clear();
    if (!string.IsNullOrWhiteSpace(textBox1.Text))
    {
        string LinesToDelete = textBox1.Text;
        var Lines = File.ReadAllLines(@"E:\sample.txt");
        if (Lines.Contains(textBox1.Text))
        {
            var newLines = Lines.Where(line => !line.Contains(LinesToDelete));
            File.WriteAllLines(@"E:\sample.txt", newLines);
            textBox2.Text = "Removed";
        }
        else
        {
            textBox2.Text = "Not found";
        }
    }
