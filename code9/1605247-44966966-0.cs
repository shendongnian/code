            byte[] bytes = null;
           // byte[] bytes2 = null;
            try
            {
                HttpPostedFile postedFile = file.PostedFile;
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);
                int filesize = postedFile.ContentLength;
                Stream stream = postedFile.InputStream;
                BinaryReader binaryreader = new BinaryReader(stream);
                bytes = binaryreader.ReadBytes((int)stream.Length);
                return bytes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
