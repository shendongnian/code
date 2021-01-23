    Image deserializedImage = null;
    using (var memoryStream = new MemoryStream(bytes, false))
    {
        deserializedImage = (Image)formatter.Deserialize(memoryStream);
    }
    deserializedImage.Save("desrializedImage.jpg");
