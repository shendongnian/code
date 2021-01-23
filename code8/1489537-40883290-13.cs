    [HttpGet]
    public async Task<IActionResult> Index() {
        var classroom = new ClassRoom();
         ... //add some students to the classroom
        return View(classroom);
    }
    [HttpPost]
    public async Task<IActionResult> Index(ClassRoom classRoom) {
        ...
    }
