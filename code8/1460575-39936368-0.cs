    List<List<Point3d>> handoverPopulation = createPopulation(pts, p);
    List<double> handoverFitness = calculateFitness(handoverPopulation, p0);
    List<KeyValuePair<List<Point3d>, double>> list = new List<KeyValuePair<List<Point3d>, double>>();
    for(int i = 0; i < handoverFitness.Count; i++)
    {
     list.Add(new KeyValuePair<List<Point3d>, double>(handoverPopulation[i], handoverFitness[i]));
    }
    list.Sort((x, y) => x.Value.CompareTo(y.Value));
