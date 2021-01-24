    private static Dictionary<int,string> Cache = new Dictionary<int,string>();
    public static string GetSubitemValue(int id)
    {
        if (!Dictionary.Contains(id))
        {
            Dictionary[id]
                = Items.SelectMany(i => i.Subitems)
                       .FirstOrDefault(si => si.id == id).Value;
        }
        return Dictionary[id];
    }
