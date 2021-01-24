    // Get the number of fields present in the reader....
    int count = reader.FieldCount;
    // Read one record at time
    while(reader.Read())
    {
        // Create a textbox for each field in the record
        for (int i = 0; i < count; i++)
        {
            TextBox txt1 = new TextBox();
            // Set its location on screen
            // Probably if you have many fields you need to 
            // use a better algorithm to calculate x,y position 
            txt1.Location = new Point(x, y);
            txt1.Text = reader[i].ToString();
            txt1.Name = i.ToString();
            x = x + 25;
            y = y + 25;
            panel1.Controls.Add(txt1);
        }
    }
