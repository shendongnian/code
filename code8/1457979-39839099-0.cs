    string query1 = "SELECT photo, name FROM Artist";
    SqlCommand cmd = new SqlCommand(query1, conn);
    conn.Open();
    SqlDataReader reader = cmd.ExecuteReader();
    while(reader.Read())
    {
        byte[] bytes = (byte[])reader.GetValue(0);
        string strBase64 = Convert.ToBase64String(bytes);
        ImageButton imgButton = new ImageButton();
        imgButton.ImageUrl = "data:Image/png;base64," + strBase64;
        imgButton.Width = Unit.Pixel(200);
        imgButton.Height = Unit.Pixel(200);
        imgButton.Style.Add("padding", "5px");
        imgButton.Click += new ImageClickEventHandler(imgButton_Click);
        Panel1.Controls.Add(imgButton);
        Label lbl = new Label();
        lbl.Text = reader.GetValue(1);
        // TODO: add styling and sizing parameters here
        Panel1.Controls.Add(lbl);
    }
