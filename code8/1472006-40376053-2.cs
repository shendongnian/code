        private static Rectangle CreateRectangle(string name, float width, float height, int sideOfParent, float offset, Rectangle parent)
        {
            Rectangle rect = new Rectangle() { Name = name, Width = width, Height = height, Offset = offset };
            // Calculate which side should be at the bottom, depending on the bottom side of the parent, 
            // and which side of the parent the new rectangle should be attached to
            rect.BottomSide = (parent.BottomSide + 6 - sideOfParent) % 4;
            // Calculate the bottom mid point of the rectangle
            // If | bottom side parent - bottom side child | = 2, just take over the mid bottom point of the parent
            if (Math.Abs(parent.BottomSide - rect.BottomSide) == 2) { rect.MidBottom = parent.MidBottom; }
            else
            {
                // Alternative cases
                // Formulas for both bottom side parent = 0 or 2 are very similar per bottom side child variation (only plus/minus changes for Y formulas)
                // Formulas for both bottom side parent = 1 or 3 are vary similar per bottom side child variation (only plus/minus changes for X formulas)
                // Therefor, we create a "mutator" 1 / -1 if needed, to multiply one part of the formula with, so that we either add or subtract
                Point parPoint = parent.MidBottom;
                if (parent.BottomSide % 2 == 0)
                {
                    // Parent has 0 or 2 at the bottom
                    int mutator = (parent.BottomSide == 0) ? 1 : -1;
                    switch (rect.BottomSide % 2 == 0)
                    {
                        case true: rect.MidBottom = new Point(parPoint.X, parPoint.Y - (mutator * parent.Height)); break;
                        case false:
                            if (rect.BottomSide == 1) rect.MidBottom = new Point(parPoint.X + (parent.Width / 2), parPoint.Y - (mutator * (parent.Height / 2)));
                            else rect.MidBottom = new Point(parPoint.X - (parent.Width / 2), parPoint.Y - (mutator * (parent.Height / 2)));
                            break;
                    }
                }
                else
                {
                    // Parent has 1 or 3 at the bottom
                    int mutator = (parent.BottomSide == 1) ? 1 : -1;
                    switch (rect.BottomSide % 2 == 1)
                    {
                        case true: rect.MidBottom = new Point(parPoint.X + (mutator * parent.Height), parPoint.Y); break;
                        case false:
                            if (rect.BottomSide == 0) rect.MidBottom = new Point(parPoint.X + (mutator * (parent.Height / 2)), parPoint.Y - (parent.Width / 2));
                            else rect.MidBottom = new Point(parPoint.X + (mutator * (parent.Height / 2)), parPoint.Y + (parent.Width / 2));
                            break;
                    }
                }
            }
            return rect;
        }
