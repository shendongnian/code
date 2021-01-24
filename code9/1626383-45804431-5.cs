    private string ItemsAsJson(List<string> jsonItemList)
    {
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < jsonItemList.Count; i++)
        {
            builder.Append("{ \"");
            builder.Append(i);
            builder.Append("\":");
            builder.Append(jsonItemList[i]);
            builder.Append("},");
        }
        return builder.ToString();
    }
