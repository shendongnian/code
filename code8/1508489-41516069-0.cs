    StringBuilder builder = new StringBuilder();
    while (!file.EndOfStream)
    {
       line = file.ReadLine();
       builder.Append(file.ReadLine());
    }
    textBox.Text = builder.ToString();
