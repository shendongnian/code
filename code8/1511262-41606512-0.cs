    MemoryStream ms = new MemoryStream();
    PIC1.Image.Save(ms, PIC1.Image.RawFormat);
    byte[] byteImage = ms.ToArray();
    
    MemoryStream ms1 = new MemoryStream();
    PIC2.Image.Save(ms1, PIC2.Image.RawFormat);
    byte[] byteImage1 = ms1.ToArray();
