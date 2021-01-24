    private static List<int> GetPaperCodesForStudent(string studentName,
        Dictionary<int, List<string>> enrolledStudents)
    {
        return enrolledStudents
            .Where(item => item.Value.Any(name =>
                name.Equals(studentName, StringComparison.OrdinalIgnoreCase)))
            .Select(item => item.Key)
            .ToList();
    }
