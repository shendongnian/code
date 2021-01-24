        Project project = new Project()
        {
            ID = (Guid) SelectedProject,
            ProjectCode = textProjectCode.Text,
            ClientId = (Guid)comboClient.SelectedValue, // Your client's Guid. Make sure this record exists in the database.
            ProjectStart = dateProjectStart.SelectedDate,
            Active = checkActive.IsChecked
        };
