    var positive = new Local
    {
        Id = 1,
        Number = "One"
    };
    var negative = new Local
    {
        Id = -1,
        Number = "Minus One"
    };
    negative.PositiveLocals.Add(positive);
    positive.NegativeLocals.Add(negative);
    using (var context = new Context())
    {
        context.Locals.Add(positive);
        context.Locals.Add(negative);
        context.SaveChanges();
    }
