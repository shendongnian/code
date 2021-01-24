    using (var ctx = new MyContext()) {
        ctx.MyDbSet.Where(c = c.MyColumn > 1).WithComment("Hello this is a custom comment I will write it from my code").ToArray();
        ctx.MyDbSet.Take(10).ToArray(); // no comment here
        ctx.MyDbSet.Take(10).WithComment("Again with comment");
    }
