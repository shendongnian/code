	List<Person> persons = new List<Person>()
		{
			new Person() {PersonCode = 1, Surname = "Los", Name = "Maciej", Address = "Poland, ..."},
			new Person() {PersonCode = 2, Surname = "Doe", Name = "John", Address = "USA, ..."},
			new Person() {PersonCode = 3, Surname = "McAlister", Name = "Fred", Address = "UK, ..."},
			new Person() {PersonCode = 4, Surname = "Sommer", Name = "Anna", Address = "Canada, ..."},
		};
		
	List<Absence> absences = new List<Absence>()
		{
			new Absence(){AbsenceCode = 1, TypeAbsence=1, StartingDate = new DateTime(2017,5,11), EndingDate = new DateTime(2017,5,15),
				Description = "whatever", State = "A", Person = persons[0]},
			new Absence(){AbsenceCode = 2, TypeAbsence=1, StartingDate = new DateTime(2017,5,18), EndingDate = new DateTime(2017,6,8),
				Description = "whatever", State = "A", Person = persons[1]},
			new Absence(){AbsenceCode = 3, TypeAbsence=2, StartingDate = new DateTime(2017,6,1), EndingDate = new DateTime(2017,6,12),
				Description = "whatever", State = "B", Person = persons[2]},
			new Absence(){AbsenceCode = 4, TypeAbsence=2, StartingDate = new DateTime(2017,6,1), EndingDate = new DateTime(2017,6,5),
				Description = "whatever", State = "B", Person = persons[0]},
			new Absence(){AbsenceCode = 5, TypeAbsence=1, StartingDate = new DateTime(2017,6,2), EndingDate = new DateTime(2017,6,5),
				Description = "whatever", State = "A", Person = persons[2]}
		};
	//define date-range to filter Absences data 
	DateTime dfrom = new DateTime(2017,6,5);
	DateTime dTo = new DateTime(2017,6,9);
	var LastWeekAbsencesByPerson = absences
		.Where(x=> (x.StartingDate<=dTo) && (x.EndingDate>=dfrom))
		.OrderBy(x => x.Person.Surname)
		.ThenBy(x => x.StartingDate)
		.ToList();
	foreach(var lwabp in LastWeekAbsencesByPerson)
	{
		Console.WriteLine("{0}", lwabp.ToString());
		Console.WriteLine("{0}", new string('-', 60));
	}
