    using (var context = new HelthContext())
    {
        var patients = context.Patients
            .AsNoTracking()
            .ToList();
    }
