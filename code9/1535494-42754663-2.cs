    static void SetExplicit(string file)
    {
        var f = TagLib.File.Create(file);
        var tags = (TagLib.Mpeg4.AppleTag) f.GetTag(TagLib.TagTypes.Apple);
        TagLib.ByteVector customTagName = "rtng";
        TagLib.ByteVector customTagData = new byte[] { 1 };
        var customTagFlag = (UInt32)TagLib.Mpeg4.AppleDataBox.FlagType.ContainsData;
        tags.SetData(customTagName, customTagData, customTagFlag);
        f.Save();
    }
