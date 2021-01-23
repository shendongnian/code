    Random r = new Random();
    foreach (List<Point3d> generation in currentGeneration)
    {
        int index1;
        int index2;
        index1 = r.Next(0, generation.Count);
        index2 = r.Next(0, generation.Count);
        if (index1 != index2)
        {
            Point3d cache = generation[index1];
            generation[index1] = generation[index2];
            generation[index2] = cache;
        }
    }
            
