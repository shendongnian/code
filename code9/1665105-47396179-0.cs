    	public IActionResult Surname(string letter)
		{
			string query = letter;
		  //  if(letter != null) { query = letter; }
			List<Student> studenten = new List<Student>()
			 {
			  new Student { Naam = "Johan", Achternaam = "Jacobs" },
			  new Student { Naam = "Karel", Achternaam = "Jay" },
			  new Student { Naam = "John", Achternaam = "Jas" }
			 };
			List<Student> newStudents = studenten.Where(x => x.Achternaam.ToLower().StartsWith(query.ToLower()) == true).ToList();
			ViewData["Student"] = newStudents;
			return View();
		}
