    var result = (from c in courses
                    join cl in courseLocations on c.CourseID equals cl.CourseID
                    join cs in courseSchedules on cl.CourseLocationID equals cs.CourseLocationID
                    where c.CourseStatusID == 1 && c.DeleteDate == null &&
                          (c.CourseCategoryID == 1 && cs.EndDate >= DateTime.Now || c.CourseCategoryID == 3)
                    select new
                    {
                        c.CourseID,
                        CourseName = c.Name,
                        CourseEndDate = cs.EndDate,
                        c.CourseCategoryID
                    })
                .GroupBy(arg => new
                {
                    arg.CourseID,
                    arg.CourseName,
                    arg.CourseCategoryID
                })
                .Select(grouping => new
                {
                    grouping.Key.CourseID,
                    grouping.Key.CourseName,
                    CourseEndDate = grouping.Max(arg => arg.CourseEndDate),
                    grouping.Key.CourseCategoryID
                })
                .OrderBy(o => o.CourseCategoryID)
                .ThenBy(o => o.CourseName); 
