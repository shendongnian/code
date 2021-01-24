    using (MyFile myFile = new MyFile()) 
    {
       using(MediaContent myContent = new MediaContent())
       {
         myFile.FileName = "//FilePath/etc";  
         myContent.UploadedFile = myFile;   
           myContent.KeyWords.Add(keyword);
          _MediaContentService.AddContent(myContent);  
       }
    }
