    string xmlText;
    using (var zip = ZipFile.Read(zipFileName))
    {
        var ze = zip[zipPath];
        using (var ms = new MemoryStream())
        {
            ze.Extract(ms);
            ms.Position = 0;
            using (var xml = XmlReader.Create(ms))
            {
                if(xml.ReadToFollowing("someTag"))
                {
                    xmlText = xml.ReadInnerXml();
                }
                else
                {
                    // <someTag> not found
                }
            }
        }
    }
