    var result = MyDbContext.T1s.SelectMany(t1 => t1.T2s
        .Select(t2 => new
        {
            A = t1.A,
            B = t1.B,
            C = t2.C,
            D = t2.D,
        });
