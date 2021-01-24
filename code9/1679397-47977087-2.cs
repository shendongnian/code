	foreach (var classId in teacher.SelectedClassList)
	{
		var class = new Class { ClassId = classId }; // "stub" entity
		db.Classes.Attach(class);
		teacher.Classes.Add(class); // Assuming that teacher.Classes isn't null
	}
	db.Teachers.Add(teacher); // <= Add
	db.SaveChanges();
