    TagLib.File file = TagLib.File.Create(fi.FullName);
    TagLib.Tag tag = file.GetTag(TagLib.TagTypes.Id3v2);
    
    TagLib.Id3v2.PopularimeterFrame tagInfo = TagLib.Id3v2.PopularimeterFrame.Get((TagLib.Id3v2.Tag)tag, "MusicBee", true);
    
    byte rate = tagInfo.Rating;
