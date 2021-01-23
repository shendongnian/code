    private static int[] GetTopLefts(Control c)
            {
                int top, left;
                top = c.Top;
                left = c.Left;
                if (c.Parent != null)
                {
                    int[] parentPoint = GetTopLefts(c.Parent);
                    top += parentPoint[0];
                    left += parentPoint[1];
                }
                return new int[] { top, left };
            }
