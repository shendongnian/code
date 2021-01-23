    static bool intersect(GraphicsPath gp1, GraphicsPath gp2, Graphics g) 
    {
        using (Region reg = new Region(gp1))
        {
            reg.Intersect(gp2);
            return !reg.IsEmpty(g);
        }
    }
