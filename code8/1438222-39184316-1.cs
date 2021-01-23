    List<YourClass> packages = (from x in db.Packages                                           
                              join y in db.Schools on x.SchoolID equals y.ID
                              join z in db.Sessions on x.SessionID equals z.ID
                              join w in db.Lessons on x.LessonsID equals w.ID
                              join q in db.Courses on w.CourseID equals q.ID
                              select new YourClass
                              {
                                  SchoolTitle = y.TitleEn , 
                                  SessionName = z.NameEn, 
                                  CourseTitle = q.TitleEn, 
                                  LessonPeriod = w.PeriodEn, 
                                  LessonPrice = w.PriceEn, 
                                  LessonDesc = w.DescriptionEn, 
                                  LessonPaymtd = w.PayMtdEn
                              }).ToList();
    return packages;
