    for (int i = 0; i <= RowIndex; i++)
    {
        Button btn = new Button();
        btn.Text = dv[i]["Building Number"].ToString();
        btn.Width = 50;
        btn.Height = 50;        
        flowLayoutPanel1.Controls.Add(btn);
    }
