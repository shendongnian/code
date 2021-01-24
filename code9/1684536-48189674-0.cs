    public int ReplaceNameInHistoryForPublisher(string OldName, string NewName)
    {
        var assignmentsToUpdate = _DutyAssignments
            .SelectMany(da => da.Assignments.Where(a => a.Name == OldName))
            .ToList();
        assignmentsToUpdate.ForEach(x => x.Name = NewName);
        return assignmentsToUpdate.Count;
    }
