    public IActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
    {
        ....
        var students = FetchStudents();
        ....
        return View(PaginatedList<Student>.Create(students, page ?? 1, pageSize));
    }
