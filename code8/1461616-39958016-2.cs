        ZipFile zipFile = new ZipFile();
        for(int i = 0; i < anzahlBilder; i++)
        {
            using (MemoryStream ms= new MemoryStream(Convert.FromBase64String(lehrling.passfoto)))
            {
                Image userImage = Image.FromStream(ms);   
                userImage.Save(ms, ImageFormat.Png);  
                ms.Seek(0, SeekOrigin.Begin);
                byte[] imageData = new byte[ms.Length];
                ms.Read(imageData, 0, imageData.Length);
                zipFile.AddEntry(lehrling.vorname + "." + lehrling.nachname + ".jpeg", imageData);
            }
        }
    
        zipFile.Save(Response.OutputStream);
