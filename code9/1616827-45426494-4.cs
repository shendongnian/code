    public static List<string> GetDescriptionsAsText(this Enum yourEnum)
    {       
        List<string> descriptions = new List<string>();
    
        foreach (Enum enumValue in Enum.GetValues(yourEnum.GetType()))
        {
            if (yourEnum.HasFlag(enumValue))
            {
                descriptions.Add(enumValue.GetDescription());
            }
        }
    
        return descriptions;
    }
