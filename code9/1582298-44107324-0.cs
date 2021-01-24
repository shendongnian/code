    var alreadyInDatabase = listOfStudentName.Intersect(_studentsInDatabase);
    foreach (string username in alreadyInDatabase)
    {
        Console.WriteLine($"{username} was removed, it is already in the database");
    }
    var notInDatabase = listOfStudentName.Except(_studentsInDatabase);
    listOfStudentName = notInDatabase.ToList();
