    using (var myDbContext = new MyDbContext)
    {
        var result = myDbContext.T1s
            .Where(t1 => t1.X == ...)
            .Select(t1 = new
            {
                // select the T1 properties you want
                A = t1.A,
                B = t1.B,
                // a T1 has zero or more T2s
                // select the T2s you want:
                T2s = t1.T2s
                    .Where(t2 => t2.Y == ....)
                    .Select(t2 => new
                    {   // Take the T2 properties you want
                        C = t2.C,
                        D = T2.D,
                    }),
            });
    }
