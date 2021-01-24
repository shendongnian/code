    using ExifLib;
    ...
    using (System.IO.MemoryStream stream = new System.IO.MemoryStream(buffer))
    {
        using (var reader = new ExifReader(stream))
        {
            object value = null;
            string exifstr = "";
            // ISO
            reader.GetTagValue<object>(ExifTags.ISOSpeedRatings, out value);
            if (null != value && typeof(UInt16) == value.GetType())
            {
                exifstr += ("ISO" + value.ToString());
            }
            ....
