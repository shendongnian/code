    ...
    Task<int> task1 = Task<int>.Factory.StartNew(() => 1);
    int i = task1.Result;
    Task<Test> task2 = Task<Test>.Factory.StartNew(() =>
    {
        string s = ".NET";
        double d = 4.0;
        return new Test { Name = s, Number = d };
    });
    Test test = task2.Result;
    ...
