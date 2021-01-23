    while (reader.Read())
    {
        string controlType = reader["CONTROL_NAME"].ToString();
    
        if (controlType == "TextBox")
        {
            TextBox textbox = new TextBox();
            textbox.ID = reader["ID"].ToString();
            textbox.Visible = Convert.ToBoolean(reader["Visible"]);
            textbox.ToolTip = reader["ToolTip"].ToString();
            PlaceHolder1.Controls.Add(textbox);
        }
        else if (controlType == "Label")
        {
            Label label = new Label();
            label.ID = reader["ID"].ToString();
            label.Visible = Convert.ToBoolean(reader["Visible"]);
            label.Text = reader["Text"].ToString();
            PlaceHolder1.Controls.Add(label);
        }
        else if (controlType == "Button")
        {
            //etc
        }
    }
