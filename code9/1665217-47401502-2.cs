    Position existingPosition = ...;
    Employee Employee1 = myDbContext.Employees.Add(new Employee()
    {
        Position = existingPosition;
        ...
    }
    Employee Employee2 = myDbContext.Employees.Add(new Employee()
    {
        PositionId = existingPosition.Id;
        ...
    }
