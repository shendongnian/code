    public string GetNumbersFromGuid(Guid Item)
    {
        var result = string.Empty;
        var guidArray = Item.ToString().ToCharArray();
        int n;
        foreach (var item in guidArray)
        {
            if (int.TryParse(item.ToString(), out n) == true)
            {
                result += item.ToString();
            }
        }
        return result;
    }
