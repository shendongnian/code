      byte[] img = null;
      if(!String.IsNullOrEmpty(imgloc){
         FileStream fs = new FileStream(imgloc, FileMode.Open, FileAccess.Read);
         BinaryReader br = new BinaryReader(fs);
        img = br.ReadBytes((int)fs.Length);
      }
      
    
      byte[] img1 = null;
      if(!String.IsNullOrEmpty(imgloc1){
         FileStream fs1 = new FileStream(imgloc1, FileMode.Open, FileAccess.Read);
         BinaryReader br1 = new BinaryReader(fs1);
         img1 = br1.ReadBytes((int)fs1.Length);
      }
