    using(var reader = cmd.ExecuteReader())
    {
      if(reader.Read())
      {
        /// Considering GetDateTime returns a DateTime object...
        DateTime dtTemp = reader.GetDateTime(fieldIndex);
        textBox1.Text = dtTemp.toString("dddd");
      }
    }
