    /// <summary>
    /// recursive solution (backtracking)
    /// </summary>
    /// <param name="Technicians">All technicians (possibly pre-filtered so they have at least one relevant certificate)</param>
    /// <param name="DistinctSlots">The resulting statute assignment. The input needs to satisfy correctnessRule(DistinctSlots)</param>
    /// <param name="ProcessingSet">The statute IDs to be assigned according to the rules</param>
    /// <param name="completenessRule">A predicate that checks the completeness of a result. It will be applied when a possible solution is fully assigned</param>
    /// <param name="correctnessRule">A predicate that checks the correctness of an assignment. It needs to be true even for valid sub-results where some statutes are not assigned</param>
    /// <returns>True if DistinctSlots contains a solution</returns>
    private static bool FillSlots(List<Technician> Technicians, Dictionary<int, Technician> DistinctSlots, IEnumerable<int> ProcessingSet, Predicate<Dictionary<int, Technician>> completenessRule, Predicate<Dictionary<int, Technician>> correctnessRule)
    {
        if (!ProcessingSet.Any())
        {
            return completenessRule(DistinctSlots);
        }
        var key = ProcessingSet.First();
        var nextSet = ProcessingSet.Skip(1);
        foreach (var tech in Technicians.Where(x => x.StatutesHistory.Any(y => y.StatuteID == key)))
        {
            DistinctSlots[key] = tech;
            if (correctnessRule(DistinctSlots) &&
                FillSlots(Technicians, DistinctSlots, nextSet, completenessRule, correctnessRule))
            {
                return true;
            }
        }
        DistinctSlots.Remove(key);
        return false;
    }
