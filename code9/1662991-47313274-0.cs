    [Test]
    public void SomeTest() {
        // Note the subtle bug: I Reverse only once, because I want the test to fail
        Func<int[],bool> revRevIsOrig = xs => xs.Reverse().SequenceEqual( xs );
        Prop.ForAll(revRevIsOrig).QuickCheckThrowOnFailure();
    }
