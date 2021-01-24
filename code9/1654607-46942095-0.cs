    [TestMethod]
    public void Test()
    {
        var folder = Path.Combine(Path.GetTempPath(), "Snapshots");
        string data = "example data";
        string filename = Path.Combine(folder, "Test.snap");
        File.WriteAllText(filename, json);
    }
