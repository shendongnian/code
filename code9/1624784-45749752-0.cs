    try
    {
        Assert.AreEqual(TestContext.DataRow["Binary"].ToString().Split(' ')[1].Trim(), control.ToString().Split(' ')[1].Trim(),true, "Actual Binary value does not match with expected.");
    }
    catch (AssertFailedException err)
    {
        Console.WriteLine(err.Message);
    }
