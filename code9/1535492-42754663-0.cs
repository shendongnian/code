    static void SetExplicit(string file)
    {
        var f = TagLib.File.Create(file);
        TagLib.Mpeg4.AppleTag customTag = (TagLib.Mpeg4.AppleTag)f.GetTag(TagLib.TagTypes.Apple, true);
        var vector = new TagLib.ByteVector();
        vector.Add((byte)1);
        customTag.SetData("rtng", vector, (int)TagLib.Mpeg4.AppleDataBox.FlagType.ContainsData);
        f.Save();
    }
