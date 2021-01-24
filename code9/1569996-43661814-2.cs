    Random r = new Random();
    IList<ProjectEnrolment> projectEnrolments = projects.SelectMany(p => users.OrderBy(u => r.Next()).Take(2).Select(u => new ProjectEnrolment {
        EnrolmentType = enrolmentTypes[r.Next(enrolmentTypes.Count)],
        Project = p,
        User = u
    })).ToList();
