    public ICollection<Assignment> GetAssignments(ISpecification<Assignment> specification)
    {    
        return (from a in Set
                        .Where(specification.ToExpression())
                    select a)
                .ToList(queryOptions);
    }
