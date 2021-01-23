    textBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");
    textBox2.Text = DateTime.Now.ToString("HH:mm:ss");
    using(var cn = new SqlConnection(...))
    {
        using(var command = new SqlCommand("", cn)
        {
            command.CommandText = "INSERT INTO datee(date_m,heur_m) VALUES (@sqltime, @sqltime1);
            command.Parameters.AddWithValue(@sqlTime, textBox1.Text);
            command.Parameters.AddWithValue(@sqlTime1, textBox2.Text);
            cn.open();
            command.ExecuteNonQuery();
        }
    }
