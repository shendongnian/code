    [TestFixture]
    public class MyClass
    {
        public class PointTextCase
        {
            public string TestName { get; private set; }
            public Point P1 { get; set; }
            public Point P2 { get; set; }
            public double Result { get; set; } 
            public PointTextCase(Point p1, Point p2, double result)
            {
                P1 = p1;
                P2 = p2;
                Result = result;
            }
            public override string ToString()
            {
                return TestName;
            }
        }
        private static IEnumerable<PointTextCase> PointTestCases
        {
            get
            {
                yield return new PointTextCase(new Point { x = 1, y = 2 }, new Point { x = 7, y = 8 }, 8);
                yield return new PointTextCase(new Point { x = 2, y = 7 }, new Point { x = -8, y = -6 }, -12);
            }
        }
        
        [Test, TestCaseSource("PointTestCases")]
        public void GetLength_TEST(PointTextCase pointTestCase)
        {
            double output = Program.GetLength(pointTestCase.P1, pointTestCase.P2);
            output *= 1000;
            output = Math.Truncate(output);
            output /= 1000;
            Assert.AreEqual(pointTestCase.Result, output);
        }
    }
    public static class Program
    {
        public static double GetLength(Point p1, Point p2)
        {
            //some logic/calculation
            return p1.x * p2.y;
        }
    }
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }
    }
