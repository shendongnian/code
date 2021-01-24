    [Test]
    public void AfterResetGivenCellShouldNotHaveNeighbors()
    {
        // Arrange
        var cell = new Cell { X = 1, Y = 1, Value = "central" };
        var neighborCell = new new Cell { X = 1, Y = 2, Value = "neighbor" };
        var table = new Table(new[] { cell, neighborCell });
        // table.AreNeighborCellsSet(cell.X, cell.Y) - should return true at this moment
        // Act
        table.Reset();
        // Assert
        table.AreNeighborCellsSet(cell.X, cell.Y).Should().BeFalse();
    }
