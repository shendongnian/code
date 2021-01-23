    foreach (var person in people)
    {
       int personID = person.ResourceID;   
       person.webappPupil = from u in _webappCtx.CompanyWebAppViews
                            where (u.PupilID == personID)
                            select new WebAppDTO()
                            {
                               webappDate = u.webappDate.ToString(),
                               webappID = u.ID,
                            }.ToList();
       person.webappTeacher = from u in _webappCtx.CompanyWebAppViews
                            where (u.TeacherID == personID)
                            select new WebAppDTO()
                            {
                               webappDate = u.webappDate.ToString(),
                               webappID = u.ID,
                            }.ToList();   
    }
