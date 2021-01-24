    [FsCheck.NUnit.Property(Verbose = true)]
    public void SomeTest()
    {
        Func<int[],bool> revRevIsOrig = xs => xs.Reverse().SequenceEqual( xs );
        return Prop.ForAll(revRevIsOrig);
    }
