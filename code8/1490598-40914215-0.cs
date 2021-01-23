      "update memberprojects " +
      "join teammembers on Member = teammembers.TeamMembersID " +
      "join projects on Project = projects.ProjectsID " +
      "set HoursWorkedOnProject = HoursWorkedOnProject + " + hoursWorked + " " +
      "where teammembers.Name = '" + teamMember + "'  and projects.ProjectName = '" + projectName + "'", conn))
      cmd.ExecuteNonQuery();
