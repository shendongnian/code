    private dynamic Get() => new { Name = "SomeName", Age = 31 };
    private void TestGet()
    {
       var obj = Get();
       var name = obj.Name;
       var age = obj.Age;
    }
