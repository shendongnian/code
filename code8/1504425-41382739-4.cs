        if (dr.Read())
        {
            MessageBox.Show(dr.GetString(0));
        }
        else
        {
            MessageBox.Show("123");
        }
