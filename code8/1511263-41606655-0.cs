            byte[] byteImage1;
            using(MemoryStream ms = new MemoryStream())
            {
                PIC1.Image.Save(ms, PIC1.Image.RawFormat);
                byteImage1 = ms.ToArray();
            }
