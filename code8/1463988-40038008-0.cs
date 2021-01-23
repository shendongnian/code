            byte[] bytes;
            using (var stream = new System.IO.MemoryStream())
            {
                bannerSource.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                bytes = stream.ToArray();
            }
            Response.ContentType = "image/jpeg";
            Response.Clear();
            Response.BinaryWrite(bytes);
            Response.End();
