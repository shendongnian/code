    string[] subject = { "a", "b", "c", "d" };
    string[] forbidden = { "c", "d" };
    Assert.IsEmpty(subject.Intersect(forbidden)); 
    // Or:
    Assert.That(subject.Intersect(forbidden), Is.Empty);
