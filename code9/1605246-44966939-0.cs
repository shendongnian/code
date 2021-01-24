    private void ConvertImages() {
      try {
        //Process first file.
        HttpPostedFile postedFile = Upload1.PostedFile;
        byte[] ReadImage(postedFile);
        //Now do whatever you want with first file. Maybe save it?
        //Process second file.
        postedFile = Upload2.PostedFile;
        byte[] ReadImage(postedFile);
        //Now do whatever you want with second file. Maybe save it?
      } catch (Exception ex) {
        //Handle exceptions.
      }
    }
    
    private byte[] ReadImage(HttpPostedFile postedFile) {
        string filename = Path.GetFileName(postedFile.FileName);
        string fileExtension = Path.GetExtension(filename);
        int filesize = postedFile.ContentLength;
    
        Stream stream = postedFile.InputStream;
        BinaryReader binaryreader = new BinaryReader(stream);
    
        return binaryreader.ReadBytes((int) stream.Length);
    }
