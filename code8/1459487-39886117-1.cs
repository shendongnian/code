    var avgerages = db.Courses
                      .Where(c => c.Score != null)
                      .GroupBy(g => g.StudentId, c => c.Score )
                      .Select(g => new 
                       {
                           StudentId = g.Key,
                           Average = g.Average()
                       });
                    
