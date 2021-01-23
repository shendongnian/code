      Dictionary<Test, Action<string>> actions = new Dictionary<Test, Action<string>>()
                {
                    {Test.AA, (x) => { Console.WriteLine("AA: " + x); }},
                    {Test.BB, (x) => { Console.WriteLine("BB: " + x); }},
                };
    
                actions[Test.AA]("hello");
