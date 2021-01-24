    [TestMethod]
    public void SetNameTest()
    {
        var p1 = new DateTimePeriod { From = DateTime.MinValue, To = DateTime.MaxValue };
        var p2 = new DateTimePeriod { From = DateTime.MaxValue, To = DateTime.MinValue };
        var x = new Name { AName = "Jack", Valid = p1, Id = "123" };
        var y = new Name { AName = "John", Valid = p2, Id = "321" };
        b.SetValue(ref x, y);
        Assert.AreEqual("John", x.AName);
        Assert.AreEqual(p2, x.Valid);
        Assert.AreEqual("321", x.Id);
    }
