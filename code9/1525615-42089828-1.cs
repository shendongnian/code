    private bool PointExistsInAnotherList(List<PointF>[] lists, int k, PointF p)
    {
        return Enumerable.Range(0, lists.Length)
                         .Where(i => i != k)
                         .Any(list => list.Any(point => point.Equals(p)));
                                  
    }
