    using (FileStream fileStream = File.OpenRead(imageFolderPath + "\\" + file.Name))
    {
       try
       {
          var faces = await faceServiceClient.DetectAsync(fileStream, true, true);
    
          if (faces != null)
          {
             foreach (var face in faces)
             {
                var rect = face.FaceRectangle;
                var landmarks = face.FaceLandmarks;
             }
          }
          else
          {
             Console.WriteLine("No face found in image: " + file.FullName);
          }
       catch (Exception ex)
       {
          Console.WriteLine("Error");
       }
    }
