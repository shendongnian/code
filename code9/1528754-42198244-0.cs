    private ContenderLeague GetWeightApproximationMatch(IEnumerable<ContenderLeague> group, ContenderLeague contender)
    {
        return group.Aggregate(group[0] ,(selected, checking) =>
        {
            double a = selected.Contender.Weight - contender.Contender.Weight;
            double b = checking.Contender.Weight - contender.Contender.Weight;
    
            return Math.Abs(b) < Math.Abs(a) ? checking : selected;
        });
    }
