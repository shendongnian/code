    var result = myDbContext.T2s
            .Where(t2 => t2.Y == ...)
            .Select(t1 = new
            {
                // select the T1 properties you want
                C = t2.C,
                D = t2.C,
                // a T2 has zero or more T1s
                // select the T1s you want:
                T1s = t2.T1s
                    .Where(t1 => t1.Y == ....)
                    .Select(t1 => new
                    {   // Take the T1 properties you want
                        A = t1.A,
                        B = T2.B,
                    }),
            });
