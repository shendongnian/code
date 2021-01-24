    public void RemoveNegative(Point p) {
        while (p != null) {
            Point nextPoint = p.Next;
            while (nextPoint != null && nextPoint.Value < 0) {
                nextPoint = nextPoint.Next;
            }
            p.Next = nextPoint;
            p = nextPoint;
        }
    }
