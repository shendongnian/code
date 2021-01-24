    int count = reader.FieldCount;
    while(reader.Read())
    {
        for (int i = 0; i < count; i++)
        {
            TextBox txt1 = new TextBox();
            txt1.Location = new Point(x, y);
            txt1.Text = reader[i].ToString();
            txt1.Name = i.ToString();
            x = x + 25;
            y = y + 25;
            panel1.Controls.Add(txt1);
        }
    }
