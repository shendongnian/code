            byte[] ImageData;
            fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
           using (con = new MySqlConnection(DBConStr))
            {
                con.Open();
                using (cmd = new MySqlCommand(qry, con))
                {
                    cmd.Parameters.Add("@pimage", MySqlDbType.Blob);
                    cmd.Parameters["@pimage"].Value = ImageData;
                    cmd.ExecuteNonQuery();
                }
            }      
  
