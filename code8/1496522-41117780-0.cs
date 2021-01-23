    // Here all students belong to the same level
    var level = Utils.GetFirstLevel();
    foreach (var student in students) {
        level.Students.Add(student);
    }
    context.Students.AddRange(students); // Probably not necessary
    context.SaveChanges();
