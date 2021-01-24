    using (var context = new Context(GetConnection()))
    {
        var joes1 = context.People.Single(p => p.Name == "Joe");
        var joes2 = context.People.Single(p => p.Name == "Joe's Dad").Children.Single(p => p.Name == "Joe");
        Assert.IsTrue(object.ReferenceEquals(joes1, joes2);
        Assert.IsTrue(object.ReferenceEquals(joes1.Info.GetType(), joes2.Info.GetType()));
        Assert.IsTrue(object.ReferenceEquals(joes1.Info, joes2.Info));
    }
