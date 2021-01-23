    var performanceAndSkills = ReturnPerformanceAndSkills(item.SkillModels);
    list.Add(new MockList
             {
                 EmployeeId = item.EmployeeId,
                 Version = item.Name,
                 performance = performanceAndSkills.Item1,
                 Skills = performanceAndSkills.Item2,
             });
    
    private static Tuple<bool, List<Skills> ReturnPerformanceAndSkills(List<SkillModel> skills) {}
