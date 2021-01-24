    ExWrapper.First(() => { Console.WriteLine("First");   throw new Exception(); })
             .Then( () => { Console.WriteLine("Second");  throw new Exception(); })
             .Then( () => { Console.WriteLine("Third");   throw new Exception(); })
             .Then( () => { Console.WriteLine("Fourth"); })
             .Execute();
