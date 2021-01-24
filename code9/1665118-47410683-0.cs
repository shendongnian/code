    let subset = TypesAndMembers.WithNameLike("m").ToHashSet()
    from i in Issues
    where i.CodeElement.IsTypeOrMember &&
           subset.Contains(i.CodeElement)
    select new { i, i.Debt, i.Severity }
