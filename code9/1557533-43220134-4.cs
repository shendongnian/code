    // tasks becomes an IEnumerable<TaskViewModel>
    var tasks = db.Tasks.Select(x => new TaskViewModel { A = x.A, B = x.B }).ToList();
    var vm = new TaskIndexViewModel
    {
        Tasks = tasks,
        Foo = bar
    };
