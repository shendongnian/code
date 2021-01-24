    private static IEnumberable<IStudent> SortStudentList(IEnumerable<IStudent> students)
    {
        return students.OrderBy(s => s.Height)
                       .ThenByDescending(s => s.Charter)
                       .ThenBy(s => s.IQ);   
    }
