    public static PersonVM ToViewModel(PersonDM model)
    {
        if (model == null)
            return new PersonVM();
        return new PersonVM
        {
            RoleID = model.RoleID,
            Name = model.Name
        };
    }
