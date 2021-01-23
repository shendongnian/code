    DateTime result;
    string s = String.Format("{0} {1}", textBox1.Text, textBox2.Text);
    if (DateTime.TryParse(s, out result))
    {
        cmd = new SqlCommand("INSERT INTO datee (date_m) VALUES (@value)", cn);
        cmd.Parameters.AddWithValue("@value", result);
        cn.Open();
        cmd.ExecuteNonQuery();
    }
