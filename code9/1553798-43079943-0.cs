    int count = oku.FieldCount;
    for (int i = 0; i < count; i++)
    {
        oku.Read();
        TextBox txt1 = new TextBox();
        Point txtyer = new Point(x, y);
        txt1.Location = txtyer;
        txt1.Text = reader["sikicerik"].ToString();
        txt1.Name = i.ToString();
        y = y + 25;
        panel1.Controls.Add(txt1);
     }
