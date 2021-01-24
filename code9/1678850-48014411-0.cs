    private void ExecuteSearchUser(object parameter)
    {
        LoadUserSearch(); 
    }
    NewUserModel.UserSearch model = new NewUserModel.UserSearch();
    private void LoadUserSearch()
    {
        DataTable table = model.GetUserData(UserLookupTextBox, SearchByComboBox);
        for (int i = 0; i < table.Rows.Count; ++i)
            UserSearch.Add(new Person()
            {
                LastName = table.Rows[i][0].ToString(),
                FirstName = table.Rows[i][1].ToString(),
                EmailAddress = table.Rows[i][2].ToString(),
            });
        table.Dispose();
    }
