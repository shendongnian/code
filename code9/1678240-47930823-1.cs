    var proc = new Proc();
    var Items = new List<MyGen<object>>();
    Items.Add(new MyGen<object>(5));
    Items.Add(new MyGen<object>("bla"));
    proc.Do(Items.ToArray());
