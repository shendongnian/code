    public static List<string> GetComments(RootObject root, string keyword)
    {
        List<string> list = new List<string>();
        foreach (Datum a in root.albums.data)
        {
            foreach (Datum2 p in a.photos.data)
            {
                if (p.comments != null)
                {
                    foreach (Datum3 c in p.comments.data)
                    {
                        if (c.message.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            list.Add(c.from.name + " - " + a.name + " - " + c.message);
                        }
                    }
                }
            }
        }
        return list;
    }
