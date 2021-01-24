    var result=(new List<(int a, int b, int c)>()
                {
                    (1, 1, 2),
                    (1, 2, 3),
                    (2, 2, 4)
                }
            ).FirstOrDefault(w => w.a == 4 && w.b == 4);
    if (result.Equals(default(ValueTuple<int,int,int>)))
    {
        Console.WriteLine("Missing!"); 
    }
