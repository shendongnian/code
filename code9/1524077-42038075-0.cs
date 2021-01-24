            public void clickAndDrag(Point pointA)
        {
            Point tmp = Cursor.Position;
            pointA.X = pointA.X + 20;
            pointA.Y = pointA.Y + 20;
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
            Cursor.Position = ConvertToScreenPixel(pointA);
            System.Threading.Thread.Sleep(1000);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            for (var i = 0; i < 10; i++)
            {
                pointA.X = pointA.X - 10;
                Cursor.Position = ConvertToScreenPixel(pointA);
                System.Threading.Thread.Sleep(200);
                mouse_event((int)(MouseEventFlags.MOVE), 0, 0, 0, 0);
            }
            
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
            Cursor.Position = tmp;
        }
