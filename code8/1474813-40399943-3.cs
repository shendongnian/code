        public static Point GetMousePositionWindowsForms()
        {
            System.Drawing.Point point = Control.MousePosition;
            return new Point(point.X, point.Y);
        }
