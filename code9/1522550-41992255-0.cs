    NewProjectForm newProjectForm = new NewProjectForm();
    if(newProjectForm.ShowDialog() == DialogResult.OK)
    {
          DataTable dt = Util.ToDataTable(ProjectParticipantTable.GetUserProjectsDetails(Util.currentUserId));
        userProjectsDGV.DataSource = dt;
    }
