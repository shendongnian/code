    string qrText = "Photo";
    QRCodeEncoder enc = new QRCodeEncoder();
    Bitmap qrcode = enc.Encode(qrText);
    // Convert the Bitmap to byte[]
    System.IO.MemoryStream stream = new System.IO.MemoryStream();
    qrcode.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
    byte[] imageBytes = stream.ToArray();
    var message = context.MakeMessage();
    Attachment attachment = new Attachment
    {
        ContentType = "image/jpg",
        ContentUrl = "data:image/jpg;base64," + Convert.ToBase64String(imageBytes),
        Name = "Image.jpg"
    };
    message.Attachments.Add(attachment);
    await context.PostAsync(message);
