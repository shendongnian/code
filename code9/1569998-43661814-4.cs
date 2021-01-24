    IList<ProjectEnrolment> projectEnrolments = projects.SelectMany(p => users.OrderBy(u => Guid.NewGuid()).Take(2).Select(u => new ProjectEnrolment {
        EnrolmentType = enrolmentTypes.OrderBy(t => Guid.NewGuid()).FirstOrDefault(),
        Project = p,
        User = u
    })).ToList();
