    using (var conn = new NpgsqlConnection(connString))
    {
        string sQL = "SELECT photo from picturetable WHERE id = 65";
        using (var command = new NpgsqlCommand(sQL, conn))
        {
            byte[] productImageByte = null;
            conn.Open();
            var rdr = command.ExecuteReader();
            if (rdr.Read())
            {
                productImageByte = (byte[])rdr[0];
            }
            rdr.Close();
            if (productImageByte != null)
            {
                using (MemoryStream productImageStream = new System.IO.MemoryStream(productImageByte))
                {
                    ImageConverter imageConverter = new System.Drawing.ImageConverter();
                    pictureBox1.Image = imageConverter.ConvertFrom(productImageByte) as System.Drawing.Image;
                }
            }
        }
    }
