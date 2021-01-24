    var model = new List<GroupVM>
    {
        new GroupVM
        {
            Key = "Section 1",
            Values = new List<ValueVM>
            {
                new ValueVM { Name = "...." },
                new ValueVM { Name = "...." }
            }
        },
        new GroupVM
        {
            Key = "Section 2",
            ....
        }
    };
    return View(model);
