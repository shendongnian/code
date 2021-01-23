    var fos = new FileOutputStream(filePath); 
    //fos.Write(new byte[buffer.Remaining()]); 
    byte[] bmpData=new byte[buffer.Position()]; 
    buffer.Position(0); //or buffer.Flip();
    buffer.Get(bmpData, 0, buffer.Remaining()); 
    
    fos.Write(bmpData); 
    fos.Close();
