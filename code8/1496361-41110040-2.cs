    StringBuilder sb = new StringBuilder();
    while (oku.Read())
    {
       sb.Append(oku.GetString("mac"));
       sb.Append(";");
    }
    textBox1.Text = sb.ToString();
