    for (int i = 1; i <= 4; i++) {
        // read from form into string variables ...
        var doWriteToDb = !string.IsNullOrWhiteSpace(StudentName)
                       || !string.IsNullOrWhiteSpace(RegistrationNumber)
                       || !string.IsNullOrWhiteSpace(Department)
                       || !string.IsNullOrWhiteSpace(FatherName);
        if (doWriteToDb) {
            Dt.Rows.Add(StudentName, RegistrationNumber, Department, FatherName);
        }
    }
