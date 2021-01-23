    List<TestDemo> list = new List<TestDemo>();
    for (int i = 0; i < 6; i++)
    {
        list.Add(new TestDemo { Key = "A", Text = $"Test A {i}" });
        list.Add(new TestDemo { Key = "B", Text = $"Test B {i}" });
    }
    var result = from t in list group t by t.Key;
    groupInfoCVS.Source = result;
