    //...other code
    var attachments = new List<string>();
    //encode attachment
    var fileInputBytes = new byte[0];
    using (var reader = new BinaryReader(order.file1.InputStream)) {
        fileInputBytes = reader.ReadBytes(order.file1.ContentLength);
    }
    if(fileInputBytes.Length > 0) {
        var attachment = Convert.ToBase64String(fileInputBytes);
        attachments.Add(attachment);
    }
    
    //...other code
