    public class GMapRouteColored : GMap.NET.WindowsForms.GMapRoute
    {
        public GMapRouteColored(IEnumerable<PointLatLng> points, string name)
            : base(points, name)
        {
        }
        public override void OnRender(Graphics g)
        {
            for(int i = 0; i < LocalPoints.Count - 1; i++)
            {
                g.DrawLine(yourPenForThisLine, LocalPoints[i].X, LocalPoints[i].Y, LocalPoints[i+1].X, LocalPoints[i+1].Y);
            }
        
        }
    }
