    var std = new Student { StudentID = 1, FirstName = "Brett", LastName = "X", Scores = new List<StudentTestScore>{ new Score { StudentTestScoreID = 1, Score = 100 }}}
      using (var context = new YOURContext())
      {
        context.Student.Add(std);
        context.SaveChanges();
      }
