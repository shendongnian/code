    public static List<double> calculateFitness(List<List<Point3d>> cF, Point3d startpoint)
    {
        List<double> Fitness = new List<double>();
        for (int i = 0; i < cF.Count; i++)  // 1.
        {
            Point3d actual;  // 2. 
            Point3d next; 
            double distance;  
            double totalDistance = startpoint.DistanceTo(cF[i][0]);  // 3.
            for (int j = 0; j < cF[i].Count - 1; j++)  // 4.
            {
                actual = cF[i][j];  // 5.
                next = cF[i][j + 1];
                distance = actual.DistanceTo(next);
                totalDistance += distance;
            }
            totalDistance += cF[i][cF[i].Count - 1].DistanceTo(startpoint);
            Fitness.Add(totalDistance); // 6.
        }
        return Fitness;
    }
