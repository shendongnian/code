    List<Models.UserInfo> v = context.User_cs
            .Join(context.UserEducation_cs, u => u.UserName, ue => ue.UserName, (u, ue) => new UserEducation_cs
            {
                UserName = ue.UserName,
                EducationId = ue.EducationId,
                StartDate = ue.StartDate,
                EndDate = ue.EndDate
            }).
            Join(context.Education_cs.GroupBy(q => q.UserName).Select(q => q.OrderByDescending(w => w.StartDate).First()), 
				 ue => ue.EducationId, e => e.EducationId, (ue, e) => new
            {
                UserName = ue.UserName,
                EducationId = ue.EducationId,
                StartDate = ue.StartDate,
                EndDate = ue.EndDate,
                Title = e.Title,
                Major = e.Major,
                MajorDetails = e.MajorDetails,
                Info = e.Info
            }).
            Join(context.Experiences.Where(ex => ex.IsWorking), lst => lst.UserName, ex => ex.UserName, (lst, ex) => new Models.UserInfo
            {
                UserName = ex.UserName,
                EducationId = lst.EducationId,
                StartDate = lst.StartDate,
                EndDate = lst.EndDate,
                Title = lst.Title,
                Major = lst.Major,
                MajorDetails = lst.MajorDetails,
                Info = lst.Info,
                IsWorking = ex.IsWorking,
                StartDate_ex=ex.StartedDate,                    
            }).ToList(); 
