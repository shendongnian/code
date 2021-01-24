    public List<IGrouping<string,DataClass.Student>> GroupBySingleProperty()
    {
        var queryLastNames =
            from student in students
            group student by student.LastName into newGroup
            orderby newGroup.Key
            select newGroup;
        return queryLastNames.ToList();
    }
