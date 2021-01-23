    to = new Tool();
    input.GroupBy(a => a[1]).ToList().ForEach(a =>
        { fa = new Factory($"{a.Key}"); a.GroupBy(b => b[2]).ToList().ForEach(b =>
            { ma = new Machine($"{b.Key}"); b.GroupBy(c => c[3]).ToList().ForEach(c =>
                { mo = new Module($"{c.Key}"); ma.Modules.Add(mo); }); fa.Machines.Add(ma); }); to.Factories.Add(fa); });
