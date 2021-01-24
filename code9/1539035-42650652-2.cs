    TagLib.File videoFile = TagLib.File.Create("test.mp4");
    TagLib.Mpeg4.AppleTag customTag = (TagLib.Mpeg4.AppleTag)f.GetTag(TagLib.TagTypes.Apple);
    customTag.SetDashBox("Producer","Producer1", "value");
    f.Save();
    f.Dispose();
    var tokenValue = customTag.GetDashBox("Producer", "Producer1");
