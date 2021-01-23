    public static List<List<Point3d>> createGenerations(List<List<Point3d>> cGP, List<double> cGF, int genSize, Point3d startPoint)
    {
     List<List<Point3d>> currentGeneration = new List<List<Point3d>>(cGP.Count);
     cGP.ForEach((item) => {currentGeneration.Add(new List<Point3d>(item));});
    }
