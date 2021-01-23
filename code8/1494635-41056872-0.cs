    internal static bool IsElementWithTextInCollection(ReadOnlyCollection<IWebElement> table, string customerFieldName)
    {        
        bool result = true;
        foreach (var item in table)
        {
            if (item.Text.Contains(customerFieldName))
            {
                result = false;
                break;
            }
        }
       return result;
    }
