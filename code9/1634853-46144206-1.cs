    public class PolygonTests
    {
        public class GivenLine : PolygonTests
        {
            private readonly Polygon _polygon = new Polygon(new List<GeographicalPoint>
            {
                new GeographicalPoint(1, 1),
                new GeographicalPoint(10, 1)
            });
            public class AndPointIsAnywhere : GivenLine
            {
                [Theory]
                [InlineData(5, 1)]
                [InlineData(-1, -1)]
                [InlineData(11, 11)]
                public void WhenAskingContainsLocation_ThenItShouldReturnFalse(double latitude, double longitude)
                {
                    GeographicalPoint point = new GeographicalPoint(latitude, longitude);
                    bool actual = _polygon.ContainsLocation(point);
                    actual.Should().BeFalse();
                }
            }
        }
        public class GivenTriangle : PolygonTests
        {
            private readonly Polygon _polygon = new Polygon(new List<GeographicalPoint>
            {
                new GeographicalPoint(1, 1),
                new GeographicalPoint(10, 1),
                new GeographicalPoint(10, 10)
            });
            public class AndPointWithinTriangle : GivenTriangle
            {
                private readonly GeographicalPoint _point = new GeographicalPoint(6, 4);
                [Fact]
                public void WhenAskingContainsLocation_ThenItShouldReturnTrue()
                {
                    bool actual = _polygon.ContainsLocation(_point);
                    actual.Should().BeTrue();
                }
            }
            public class AndPointOutsideOfTriangle : GivenTriangle
            {
                private readonly GeographicalPoint _point = new GeographicalPoint(5, 5.0001d);
                [Fact]
                public void WhenAskingContainsLocation_ThenItShouldReturnFalse()
                {
                    bool actual = _polygon.ContainsLocation(_point);
                    actual.Should().BeFalse();
                }
            }
        }
        public class GivenComplexPolygon : PolygonTests
        {
            private readonly Polygon _polygon = new Polygon(new List<GeographicalPoint>
            {
                new GeographicalPoint(1, 1),
                new GeographicalPoint(5, 1),
                new GeographicalPoint(8, 4),
                new GeographicalPoint(3, 4),
                new GeographicalPoint(8, 9),
                new GeographicalPoint(1, 9)
            });
            [Theory]
            [InlineData(5, 0, false)]
            [InlineData(5, 0.999d, false)]
            [InlineData(5, 1, true)]
            [InlineData(5, 2, true)]
            [InlineData(5, 3, true)]
            [InlineData(5, 4, false)]
            [InlineData(5, 5, false)]
            [InlineData(5, 5.999d, false)]
            [InlineData(5, 6, true)]
            [InlineData(5, 7, true)]
            [InlineData(5, 8, true)]
            [InlineData(5, 9, false)]
            [InlineData(5, 10, false)]
            [InlineData(0, 5, false)]
            [InlineData(0.999d, 5, false)]
            [InlineData(1, 5, true)]
            [InlineData(2, 5, true)]
            [InlineData(3, 5, true)]
            [InlineData(4.001d, 5, false)]
            //[InlineData(5, 5, false)] -- duplicate
            [InlineData(6, 5, false)]
            [InlineData(7, 5, false)]
            [InlineData(8, 5, false)]
            [InlineData(9, 5, false)]
            [InlineData(10, 5, false)]
            public void WhenAskingContainsLocation_ThenItShouldReturnCorrectAnswer(double latitude, double longitude, bool expected)
            {
                GeographicalPoint point = new GeographicalPoint(latitude, longitude);
                bool actual = _polygon.ContainsLocation(point);
                actual.Should().Be(expected);
            }
        }
    }
