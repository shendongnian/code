    [TestMethod]
    public void ShouldLoadAssemblyWithFileName()
    {
        string asmFile = this.GetType().Module.FullyQualifiedName;
     
        LoadCommand cmd = new LoadCommand();
        cmd.Item = asmFile;
     
        IEnumerator result = cmd.Invoke().GetEnumerator();
     
        Assert.IsTrue(result.MoveNext());
        Assert.IsTrue(result.Current is Assembly);
     
        Assert.AreEqual(this.GetType().Assembly.FullName, ((Assembly)result.Current).FullName);
    }
