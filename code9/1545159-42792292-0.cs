    foreach (var subroute in route)
    {
        int r = 0;
        while (r != subroute[subroute.Count - 1])
        {
            r = subroute[subroute.Count-1];
            for (int j = 1; j < C + 1; j++)
            {
                if (routeopt.x[r, j] == 1)
                    subroute.Add(j);
            }
        }
    }
