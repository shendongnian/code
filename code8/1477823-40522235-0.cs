    private void button3_Click(object sender, EventArgs e)
        {
        string line = null;
        string FirstLineContent = "";
        int line_number = 0;
        int line_to_delete = 1;
        string tempFile = Path.GetTempFileName();
        using (StreamReader reader = new StreamReader(@"D:\Sample.txt"))
        {
        using (StreamWriter writer = new StreamWriter(tempFile))
        {
        while ((line = reader.ReadLine()) != null)
        {
        line_number++;
        if (line_number == line_to_delete)
        {
        FirstLineContent = line;
        }
        else
        {
        writer.WriteLine(line);
        }
        }
        writer.WriteLine(FirstLineContent);
        }
        }
        File.Delete(@"D:\Sample.txt");
        File.Move(tempFile, @"D:\Sample.txt");
        }
