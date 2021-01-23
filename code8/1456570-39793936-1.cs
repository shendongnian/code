    [Test]
    public void AddToRepoIncrementsByOne()
    {
        IFile file = new FileFake();
        var obj = new { Name = "test" };
        /*Your type is missing*/ repo = CreateRepository(file, obj);
        repo.Add(obj);
        Assert.True(repo.Items.Count() == 1);
        Assert.AreEqual(repo.Items.Single().Name, obj.Nome);
        //----------------------------------^^^^  
        //-------------------no more error here
    }
