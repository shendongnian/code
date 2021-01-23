    static void Main(string[] args)
    {
        var one = new One { Property = new ZeroOrOne(), Text = "Adding related"};
        using (var context = new TestContext())
        {
            context.Database.Migrate();
            context.Ones.Add(one);
            context.SaveChanges();
        }
        one.Text = null;
        one.ZeroOrOne = null;
        one.ZeroOrOneId = null;
        using (var context = new TestContext())
        {
            context.Ones.Update(one);
            context.SaveChanges();
        }
    }
