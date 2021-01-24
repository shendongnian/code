        Project project = new Project()
        {
            ID = (Guid) SelectedProject,
            ProjectCode = textProjectCode.Text,
            ClientId = (Guid)comboClient.SelectedValue,
            ProjectStart = dateProjectStart.SelectedDate,
            Active = checkActive.IsChecked
        };
