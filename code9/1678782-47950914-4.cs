    public JSONArrayConverter(JSONNode p)
    {
        JSONArray tab = p.AsArray;
        IList<T> result = new List<T>();
        for (int i = 0; i < tab.Count(); i++)
        {
            JSONNode value = tab[i];
            result[i] = (T)Activator.CreateInstance(typeof(T), value);
        }
    }
