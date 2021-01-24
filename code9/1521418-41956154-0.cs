    // Points p1(x1,y1), p2(x2,y2)
            private Point p1, p2;
            List<Point> p1List = new List<Point>();
            List<Point> p2List = new List<Point>();
    
            int count = 0;
            // Click 2 times on image to get coordinate values for p1 & p2
            private void pbChooseDirection_MouseDown(object sender, MouseEventArgs e)
            {
                
                if(count/2 == 0)
                {
                    pbChooseDirection.Image = drawingLineImage;
                }
                
                if (p1.X == 0)
                {
                    p1.X = e.X;
                    p1.Y = e.Y;
                    count++;
                }
                else
                {
                    p2.X = e.X;
                    p2.Y = e.Y;
                    count++;
    
                    p1List.Add(p1);
                    p2List.Add(p2);
                    
                    Invalidate();
                    // Sets X to 0 and choose p1 again
                    p1.X = 0;
                }
    
            }
    
    private void pbChooseDirection_Paint_1(object sender, PaintEventArgs e)
            {
                using (var p = new Pen(Color.Blue, 4))
                {
                    for (int x = 0; x < p1List.Count; x++)
                    {
                        e.Graphics.DrawLine(p, p1List[x], p2List[x]);
                    }
                }
            }
