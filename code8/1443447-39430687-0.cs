    private static List<string> GetComments(RootObject root, string albumName, string keyword)
    {
        List<string> list = new List<string>();
        var album = root.albums.data[0];
        foreach (Datum2 p in album.photos.data)
        {
            if (p.comments != null)
            {
                foreach (Datum3 c in p.comments.data)
                {
                    if (c.message.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        list.Add(c.from.name + " - " + albumName + " - " + c.message);
                    }
                }
            }
        }
        return list;
    }
