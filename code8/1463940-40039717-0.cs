    public string BuildString()
    {
        var enumerable = GetEnumerableFromSomewhere();
        var interestingParts = enumerable.Select(v => v.TheInterestingStuff).ToArray();
    
        stringBuilder.Append("This is it: ");
    
        foreach(var part in interestingParts)
        {
            stringBuilder.AppendPart(part)
    
        }
        if (stringBuilder.Length>0)
            stringBuilder.Length--;
    }
    
    private static void AppendPart(this StringBuilder stringBuilder, InterestingPart part)
    {
        if (someCondition(part)) 
        {
            stringBuilder.Append(string.Format("[{0}] = @{0}", part.Something));         
            
        }
        else
        {
             stringBuilder.Append(string.Format("[{0}]", part.Something));
             stringBuilder.AppendInFilter(part); //
        }
    }
