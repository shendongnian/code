    Attachment data = BuildAttachment(new MemoryStream(filebytes), "QRCode.png"));
    ...
    private Attachment BuildAttachment(MemoryStream stream, string name) {
        Attachment attachment = new Attachment(stream, name);
        attachment.ContentDisposition.Inline = true;
        return attachment;
    }
