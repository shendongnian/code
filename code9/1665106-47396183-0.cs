    public IActionResult Surname(string letter)
    {
        string query = letter.ToLower();
        List<Student> studenten = new List<Student>()
        {
            new Student { Naam = "Johan", Achternaam = "Jacobs" },
            new Student { Naam = "Karel", Achternaam = "Jay" },
            new Student { Naam = "John", Achternaam = "Jas" }
        };
        List<Student> newStudents = studenten.Where(x => x.Achternaam.ToLower().StartsWith(query)).ToList();
        ViewData["Student"] = newStudents;
        return View();
    }
