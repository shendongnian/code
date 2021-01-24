    if (colorDialog1.ShowDialog() == DialogResult.OK)
    {                
        
        string color = colorDialog1.Color.ToArgb().ToString("x");
        color = color.Substring(2, 6);
        color = "#" + color;
        con.Open();
        string sql2 = ("Update Employee SET PanelColor= '" + color + "' WHERE EID='" + 17002 + "' ");
        SqlCommand cmd2 = new SqlCommand(sql2, con);
        SqlDataReader dr2 = cmd2.ExecuteReader();
        con.Close();
        MessageBox.Show(color);
        panel1.BackColor = ColorTranslator.FromHtml(color);
    }
