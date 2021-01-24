    var data = context.B
        .Select(b => new BDTO
        {
            x = b.x ...
            A = b.A
                .Select(a => new ADTO
                {
                    x = a.x ...
                }
                .ToList()
        }
        .ToList();
