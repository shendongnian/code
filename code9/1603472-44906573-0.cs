    public static string ToDisplay(this IList source, string seperator = ",")
    {
        StringBuilder str = new StringBuilder();
        foreach (var o in source)
        {
            if (o != null)
            {
                if (str.Length > 0)
                    str.Append(seperator);
                IList list = o as IList;
                if (list != null)
                    str.Append(list.ToDisplay(seperator));
                else
                    str.Append(o);
            }
        }
        return str.ToString().TrimEnd();
    }
