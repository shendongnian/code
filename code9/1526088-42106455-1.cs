    public void SaveUser(string imageData)
        {
            path = @"C:\YourCustomFolder\";  // your path needs to point to the Directory you want to save
            //Create image to local machine.
            string fileNameWitPath = path + "4200020789506" + ".png";
            //chekc if directory exist, if not, create
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
            }
            // Save fileNameWitPath variable to Database.
        }
