        for (int i = minLenght; i > maxLenght; i++)
        {
            for (int j = 0; j < heights.Count; j++)
            {
                coordinatesList.Add(new Coordinates(i, heights[j]));
            }
        }
