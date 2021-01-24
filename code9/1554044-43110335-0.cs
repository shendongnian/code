     private IEnumerable<Rectangle> GetExternalRectangles(Rectangle surface, Rectangle test)
        {
            var result = new List<Rectangle>();
            if (!test.IntersectsWith(surface)) return new List<Rectangle> { surface };
            #region Top and Bottom
            if (test.Top>surface.Top && test.Bottom < surface.Bottom) // test inside surface vertically
            {
                result.Add(new Rectangle(surface.Location, new Size(surface.Width, test.Top - surface.Top)));
                result.Add(new Rectangle(new Point(surface.Left,test.Bottom), new Size(surface.Width, surface.Bottom-test.Bottom)));
            }
            if (test.Top > surface.Top && test.Bottom > surface.Bottom) // test inside surface vertically, overflow bottom
            {
                result.Add(new Rectangle(surface.Location, new Size(surface.Width, test.Top - surface.Top)));
                //result.Add(new Rectangle(new Point(surface.Left,test.Bottom), new Size(surface.Width, surface.Bottom-test.Bottom)));
            }
            if (test.Top < surface.Top && test.Bottom < surface.Bottom) // test inside surface vertically, overflow top
            {
                //result.Add(new Rectangle(surface.Location, new Size(surface.Width, test.Top - surface.Top)));
                result.Add(new Rectangle(new Point(surface.Left, test.Bottom), new Size(surface.Width, surface.Bottom - test.Bottom)));
            }
            #endregion
            #region Lateral
            if (test.Left > surface.Left && test.Right < surface.Right) // test inside surface horizontally
            {
                result.Add(new Rectangle(new Point(surface.Left,Math.Max(surface.Top,test.Top)), new Size(test.Left-surface.Left, Math.Min(surface.Bottom, test.Bottom)- Math.Max(surface.Top, test.Top))));
                result.Add(new Rectangle(new Point(test.Right, Math.Max(surface.Top, test.Top)), new Size(surface.Right - test.Right, Math.Min(surface.Bottom, test.Bottom) - Math.Max(surface.Top, test.Top))));
            }
            if (test.Left > surface.Left && test.Right > surface.Right) // test inside surface horizontally, overflow right
            {
                result.Add(new Rectangle(new Point(surface.Left, Math.Max(surface.Top, test.Top)), new Size(test.Left - surface.Left, Math.Min(surface.Bottom, test.Bottom) - Math.Max(surface.Top, test.Top))));
                //result.Add(new Rectangle(new Point(test.Right, Math.Max(surface.Top, test.Top)), new Size(surface.Right - test.Right, Math.Min(surface.Bottom, test.Bottom) - Math.Max(surface.Top, test.Top))));
            }
            if (test.Left < surface.Left && test.Right < surface.Right) // test inside surface horizontally, overflow left
            {
                //result.Add(new Rectangle(new Point(surface.Left, Math.Max(surface.Top, test.Top)), new Size(test.Left - surface.Left, Math.Min(surface.Bottom, test.Bottom) - Math.Max(surface.Top, test.Top))));
                result.Add(new Rectangle(new Point(test.Right, Math.Max(surface.Top, test.Top)), new Size(surface.Right - test.Right, Math.Min(surface.Bottom, test.Bottom) - Math.Max(surface.Top, test.Top))));
            }
            #endregion
            return result;
        }
