    List<string> lineData = new List<string>();
            
    foreach (string fileLine in File.ReadAllLines("F:\\assign.txt"))
    {
        var delimeter = "_";
        var lineParts = fileLine.Split(new[] {delimeter}, StringSplitOptions.None);
        if (lineParts.Length > 1) lineParts = lineParts.Skip(1).ToArray();
        var data = string.Join(delimeter, lineParts.Skip(lineParts.Length - 6));
        lineData.Add(data);
        textBox3.Text = data;
        MessageBox.Show(data);
    }
    File.WriteAllLines(@"C:\Users\Adnan Haider\Desktop\line.txt", lineData);
