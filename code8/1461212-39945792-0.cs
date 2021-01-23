    if(fileUpload != null) {
        var files = fileUpload.ToList();
        for (var index = 0; index < files.Count; index++) {
            var file = files[index];
            if (index == 0) {
                client.Image1 = new byte[file.ContentLength];
                file.InputStream.Read(client.Image1, 0, file.ContentLength);
            }
            if (index == 1) {
                client.Image2 = new byte[file.ContentLength];
                file.InputStream.Read(client.Image2, 0, file.ContentLength);
            }
            if (index == 2) {
                client.Image3 = new byte[file.ContentLength];
                file.InputStream.Read(client.Image3, 0, file.ContentLength);
            }                   
        }
    }  
