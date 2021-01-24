    private void newProjectButton_Click(object sender, EventArgs e)
    {
        NewProjectForm newProjectForm = new NewProjectForm();
        newProjectForm.FormClosed += NewProjectForm_FormClosed;
        newProjectForm.Show();
    }
    private void NewProjectForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
    {
        ////will run when new form is closed
        DataTable dt = Util.ToDataTable(ProjectParticipantTable.GetUserProjectsDetails(Util.currentUserId));
        userProjectsDGV.DataSource = dt;
    }
