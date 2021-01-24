    if (para.Elements.Count > 0)
    {
        Text t = para.Elements[0] as Text;
        if (t != null)
        {
            string s = t.Content;
            ...
        }
    }
