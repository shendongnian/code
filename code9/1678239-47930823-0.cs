    var proc = new Proc();
    var MyGen = new List<MyGen<object>>();
    MyGen.Add(new MyGen<object>(5));
    MyGen.Add(new MyGen<object>("bla"));
    proc.Do(MyGen.ToArray());
