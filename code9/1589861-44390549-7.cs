    Dictionary<string, List<Student>> crossGroupDuplicates = twoGroups
        .SelectMany((group, index) => group.Students.Select(student => new { student, index }))
        .GroupBy(x => x.student.Name)
        .Where(g =>
        {
            int index = g.First().index;
            return g.Skip(1).Any(x => x.index != index);
        })
        .ToDictionary(g => g.Key, g => g.Select(x => x.student).ToList());
