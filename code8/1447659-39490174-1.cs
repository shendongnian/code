    var results = from x in context.Tests
                  group x by new { x.DeptId, x.StudentId, x.TeacherId } into grp
                  select new 
                  {
                      grp.Key.DeptId,
                      grp.Key.StudentId,
                      grp.Key.TeacherId,
                      A = grp.FirstOrDefault(x => x.TestName == "A")?.TestValue,
                      B = grp.FirstOrDefault(x => x.TestName == "B")?.TestValue
                  };
