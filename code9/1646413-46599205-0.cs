    using ExifLib;
    ...
    using (System.IO.MemoryStream stream = new System.IO.MemoryStream(buffer))
    {
            ExifReader reader = null;
            reader = new ExifReader(stream);
            if (null != reader)
            {
                using (reader)
                {
                    object value = null;
                    string exifstr = "";
                    // ISO
                    value = null;
                    reader.GetTagValue<object>(ExifTags.ISOSpeedRatings, out value);
                    if (null != value)
                    {
                        if( typeof(UInt16) == value.GetType())
                        {
                            if (0 < exifstr.Length) { exifstr += " "; }
                            exifstr += ("ISO" + value.ToString());
                        }
                    }
                    ....
