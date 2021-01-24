    string param = "1100,1110,0110,0001";
    var rJagged = param.Split(',').Select(x => x.Select(y => int.Parse(y.ToString())));
    int[,] result = new int[rJagged.Count(), rJagged.Max(x => x.Count())];
    for (int i = 0; i < rJagged.Count(); i++)
    {
        IEnumerable<int> row = rJagged.ElementAt(i);
        for (int j = 0; j < row.Count(); j++)
        {
            result[i, j] = row.ElementAt(j);
        }
    }
