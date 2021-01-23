    class ReversePolarSorter : Comparer<Point>
    {
        const int precision = 6;
        double m_baseX;
        double m_baseY;
        public ReversePolarSorter(Point basePoint)
        {
            m_baseX = basePoint.X;
            m_baseY = basePoint.Y;
        }
    
        double GetAngle(Point p)
        {
            return Math.Round(Math.Atan2(p.Y - m_baseY, p.X - m_baseX), precision);
        }
    
        public override int Compare(Point a,  Point b)
        {
            return GetAngle(a).CompareTo(GetAngle(b));
        }
    }
