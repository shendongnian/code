    int b = 1;
    foreach (MimeKit.MimeEntity bodyPart in tnefMessage.BodyParts)
    {
        if (!bodyPart.IsAttachment)
        {
            var mime = (MimeKit.MimePart) bodyPart;
            mime.ContentObject.DecodeTo(path + $"_bodyPart{b++}.{bodyPart.ContentType.MediaSubtype}");
        }
    }
