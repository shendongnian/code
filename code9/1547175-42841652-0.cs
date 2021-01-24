    using(Context ctx = new Context(connection))
    {
        for (int j = 0; j < 5; j++)
        {
        
            for (int i = 0; i < 15; i++)
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                ctx.Students.ToList();
            }
        }
    }
