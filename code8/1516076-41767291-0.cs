    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < 1000; i++)
    {
        var bytes = File.ReadAllBytes(dirPath + string.Format(@"commands{0}.txt", i));
        sb.Append(Environment.NewLine + System.Text.Encoding.UTF8.GetString(bytes));
    }
