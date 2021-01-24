    public ActionResult subcategory(string brand, ..., Dictionary<string, string> filters)
    {
        foreach(KeyValuePair<string, int> item in filters)
        {
            int category = Convert.ToInt32(item.Key.Split('-')[0]);
            int filter = item.Value;
        }
    }
