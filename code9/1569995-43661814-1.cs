    Random r = new Random();
    IList<ProjectEnrolment> projectEnrolments = new List<ProjectEnrolment>();
    foreach (Project project in projects)
    {
        int firstUser = r.Next(users.Count);
        projectEnrolments.Add(new ProjectEnrolment {
            EnrolmentType = enrolmentTypes[r.Next(enrolmentTypes.Count)],
            Project = project,
            User = users[firstUser]
        });
        int secondUser;
        do {
            secondUser = r.Next(users.Count);
        } while (secondUser == firstUser);
        projectEnrolments.Add(new ProjectEnrolment {
            EnrolmentType = enrolmentTypes[r.Next(enrolmentTypes.Count)],
            Project = project,
            User = users[secondUser]
        });
    }
