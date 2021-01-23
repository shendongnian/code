    public static IEnumerable<IMember> GetAllMembers(this IGroup group)
    {
        foreach (var member in group.Members)
        {
            if (member.IsGroup)
            {
                var nestedGroup = member as IGroup;
                foreach (var nestedMember in nestedGroup.GetAllMembers())
                {
                    yield return nestedMember;
                }                
            }
            else
            {
                yield return member;
            }
        }
    }
