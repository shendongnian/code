    public static List<string> GetDescriptionsAsText(this Enum yourEnum)
    {       
        List<string> descriptions = new List<string>();
    
        foreach (Enum result in Enum.GetValues(yourEnum.GetType()))
        {
            if (yourEnum.HasFlag(result))
            {
                descriptions.Add(result.GetDescription());
            }
        }
    
        return descriptions;
    }
