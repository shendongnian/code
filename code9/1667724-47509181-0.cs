    [Test]
    public void AssertFoodSpawnsOnNewLocationWhenEaten()
    {
        Position expected = _sut.Food.Pos;
        _sut.FeedSnake();
        Position result = _sut.Food.Pos;
        Assert.False(IsPositionEqual(expected, result));
    }
        
    private bool IsPositionEqual(Position Pos1, Position Pos2)
    {
        if (Pos1.XCoordinate == Pos2.XCoordinate &&
            Pos1.YCoordinate == Pos2.YCoordinate)
            {
                return true;
            }
            return false;
    }
