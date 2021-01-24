    private void newProjectButton_Click(object sender, EventArgs e)
    {
        NewProjectForm newProjectForm = new NewProjectForm();
        newProjectForm.FormClosed += NewProjectForm_FormClosed;
        newProjectForm.Show();
    }
    private void NewProjectForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
    {
        ////wait for newProjectForm to close...
        DataTable dt = Util.ToDataTable(ProjectParticipantTable.GetUserProjectsDetails(Util.currentUserId));
        userProjectsDGV.DataSource = dt;
    }
