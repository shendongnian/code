    var db = new MyEfContext(); // Or however you create or get your ef context IoC maybe?
    
    IEnumerable<Task> tasks = db.Tasks
        .Select(e => Mapper.Map<DTO.Task>(e));
    var vm = new TaskIndexViewModel
    {
        Tasks = tasks,
        CategoryName = "This Cool Cat"
    };
