    private static int[] StatuteIDs = new int[] { 6, 11, 12, 8, 9 };
    private static bool CompletenessRule(Dictionary<int, Technician> assignment)
    {
        // ensure all statuteIDs are available as keys in the dictionary and all values are not-null
        return !StatuteIDs.Except(assignment.Keys).Any() &&
            assignment.Values.All(x => x != null);
    }
