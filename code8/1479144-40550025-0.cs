     con.Open();
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select prumos from dbo.modelos";
        int value = (int)cmd.ExecuteScalar();
        if (value == 2) ; //database value prumos =2
        {
            textBox13.Visible = true;
            textBox18.Visible = true;
            textBox17.Visible = true;
            label16.Visible = true;
            return;
        }
        else if (value == 3) ; //database value prumos = 3 
        {
            textBox13.Visible = true;
            textBox18.Visible = true;
            textBox17.Visible = true;
            textBox14.Visible = true;
            textBox16.Visible = true;
            textBox15.Visible = true;
            label16.Visible = true;
            label20.Visible = true;
            return;
        }
