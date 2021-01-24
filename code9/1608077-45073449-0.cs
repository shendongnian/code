           /// <summary>
        ///1 Convert String to Image
        /// </summary>
        /// <param name="commands"></param>
        /// <returns></returns>
        public Image ConvertStringtoImage(string commands)
        {
            byte[] photoarray = Convert.FromBase64String(commands);
            MemoryStream ms = new MemoryStream(photoarray, 0, photoarray.Length);
            ms.Write(photoarray, 0, photoarray.Length);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
        /// <summary>
        ///2. Read picture from Database and return as image
        /// just change the mysql to sql server type.
        /// </summary>
        /// <param name="commands"></param>
        /// <returns></returns>
        public Image Readphotofromdb(string commands)
        {
            Image image = null;
            using (MySqlConnection dbConn = new MySqlConnection(connector))
            {
                using (MySqlCommand cmd = new MySqlCommand(commands, dbConn))
                {
                    dbConn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] photoarray = Convert.FromBase64String(reader.GetString(0));
                            MemoryStream ms = new MemoryStream(photoarray, 0, photoarray.Length);
                            ms.Write(photoarray, 0, photoarray.Length);
                            image = new Bitmap(ms);
                        }
                    }
                }
            }
            MySqlConnection.ClearAllPools();
            return image;
            
        }
        /// <summary>
        /// 3. Convert Image to base64 string
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public string ConvertImageToString(Image image)
        {
            byte[] byteArray = new byte[0];
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Close();
                byteArray = stream.ToArray();
            }
            string base64String = Convert.ToBase64String(byteArray);
            return base64String;
        }
