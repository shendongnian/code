    private static IEnumberable<IStudent> SortStudentList(IEnumerable<IStudent> students)
    {
        // Notice the use of s.School.Charter
        return students.OrderBy(s => s.Height)
                       .ThenByDescending(s => s.School.Charter)
                       .ThenBy(s => s.IQ);   
    }
