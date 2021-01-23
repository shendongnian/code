        public static void Main(string[] args)
        {
            var p1 = new Point(0, 0);
            var p2 = new Point(0, 1);
            var p3 = new Point(0, 2);
            var p4 = new Point(1, 2);
            var p5 = new Point(1, 1);
            var p6 = new Point(1, 0);
            var p7 = new Point(2, 0);
            var p8 = new Point(2, 1);
            p1.ConnectWith(p2);
            p2.ConnectWith(p3);
            p3.ConnectWith(p4);
            p4.ConnectWith(p5);
            p5.ConnectWith(p6);
            p6.ConnectWith(p1);
            p6.ConnectWith(p7);
            p7.ConnectWith(p8);
            p8.ConnectWith(p5);
            var rooms = new[] { p1, p2, p3, p4, p5, p6, p7, p8 }.GetRooms();
        }
