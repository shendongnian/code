    [Test]
    public void WhenTargetIsDriverAndSourceIsDriver_Score1GetsValueFromScore1()
    {
        int score1 = 666;
        var source = new Score
        {
            Score1 = score1,
            Score2 = 667
        };
        var destination = new Score();
    
        MappingDrivers.Move(source, "Driver", destination, "Driver");
    
        Assert.AreEqual(score1, destination.Score2);    // Intentionally failing, it should be Assert.AreEqual(score1, destination.Score1);
    }
