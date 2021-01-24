                var line = new List<Point>
            {
                new Point("A", 0, 0),
                new Point("B", 1, 0),
                new Point("C", 1, 1),
                new Point("D", 3, 1),
                new Point("E", 3, 2),
                new Point("F", 4, 2)
            };
            var p = new Point("P",2,1);
            Point first = null;
            foreach (var point in line)
            {
                if (first != null)
                {
                    if (p.X == first.X && p.X == point.X
                        && (p.Y >= first.Y && p.Y <= point.Y
                            || p.Y <= first.Y && p.Y >= point.Y))
                    {
                        PrintResult(first, p, point);
                        break;
                    }
                    if (p.Y == first.Y && p.Y == point.Y
                        && (p.X >= first.X && p.X <= point.X
                            || p.X <= first.X && p.X >= point.X))
                    {
                        PrintResult(first, p, point);
                        break;
                    }
                }
                first = point;
            }
            Console.ReadKey();
        }
        private static void PrintResult(Point first, Point p, Point second)
        {
            Console.WriteLine(first.Name);
            Console.WriteLine(p.Name);
            Console.WriteLine(second.Name);
        }
