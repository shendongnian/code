      Dictionary<int, Student> dict = lstStudents
        .ToDictionary(item => item.StudentID, item => item);
      // root
      Student s = dict[lstStudents
        .Select(item => item.StudentID)
        .Except(lstStudents
           .Where(item => item.FollowedBy.HasValue)
           .Select(item => item.FollowedBy.Value))
       .First()];
      for (; s != null; s = s.FollowedBy == null? null : dict[s.FollowedBy.Value]) {
        Console.WriteLine(s.Name);
      }
