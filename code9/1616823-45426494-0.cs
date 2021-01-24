    public static List<string> GetDescriptionsAsText(this Result yourEnum)
    {
        List<string> descriptions = new List<string>();
    
        foreach (Result result in Enum.GetValues(typeof(Result)))
        {
            if (yourEnum.HasFlag(result))
            {
                descriptions.Add(result.GetDescription());
            }
        }
    
        return descriptions;
    }
