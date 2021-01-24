    private string ItemsAsJson(List<string> jsonItemList)
    {
        string ItemAsJson = "";
        for (int i = 0; i < jsonItemList.Count; i++)
        {
            string index = i.ToString();
            ItemAsJson += "{ \"" + index + "\": " + jsonItemList[i] + "},";
        }
        return ItemAsJson;
    }
