    private static Expression<Func<Student, StudentViewModel>> Selector()
    {
        if (Condition())
            return x => new StudentViewModel
            {
                Name = x.Property1,
                OtherName = x.OtherName
            };
        return x => new StudentViewModel
        {
            Name = x.Property2,
            OtherName = x.OtherName
        };
    }
