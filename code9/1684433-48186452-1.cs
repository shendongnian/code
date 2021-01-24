    class Super
    {
        int Id;
    }
    class Sub : Super
    {
        new string Id;
    }
    static class Another
    {
        static void AssignId(Super test, int val)
        {
            test.Id = val;
        }
        static Super ShowId(Super test)
        {
            return test.Id;
        }
    }
...
    var test = new Sub
    {
        Id = "SUB123"
    };
    
    Another.AssignId(test, 123);
    Console.WriteLine(Another.ShowId(test)); // 123
    Console.WriteLine(test.Id); // SUB123
