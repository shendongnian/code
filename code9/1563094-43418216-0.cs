        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var expectedCells = new Cell[2, 2];
            expectedCells[0, 0] = new Cell { Value = string.Empty };
            expectedCells[0, 1] = new Cell { Value = string.Empty };
            expectedCells[1, 0] = new Cell { Value = string.Empty };
            expectedCells[1, 1] = new Cell { Value = string.Empty };
            var cells = new Cell[2,2];
            cells[0,0] = new Cell { Value = "00" };
            cells[0,1] = new Cell { Value = "01" };
            cells[1,0] = new Cell { Value = "10" };
            cells[1,1] = new Cell { Value = "11" };
            var table = new Table(cells);
            // Act
            table.Reset();
            // Assert
            cells.ShouldBeEquivalentTo(expectedCells); // using FluentAssertions 
        }
