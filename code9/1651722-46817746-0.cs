            con.Open();
            byte[] pict = (byte[])cmd.ExecuteScalar();
            con.Close();
            ctx.Response.ContentType = "image/bmp";
            if (pict.Length <= 1) {
                // the BLOB is not a picture
                byte[] txt = ImageToByteArray(DrawText("no image found"));
                ctx.Response.OutputStream.Write(txt, 0, txt.Length);
            } else {
                // stream the picture data from BLOB
                ctx.Response.OutputStream.Write(pict, 0, pict.Length);
            }
