      using (SqlConnection con = new SqlConnection(connectionString))
      {
            MemoryStream ms = new MemoryStream();
            pictureBox4.Image.Save(ms, pictureBox4.Image.RawFormat);
            byte[] a = ms.GetBuffer();
            ms.Close();
            ...........
      }
