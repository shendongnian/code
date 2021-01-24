    string param = "1100,1110,0110,0001";
    var rJagged = param.Split(',').Select(x => x.Select(y => int.Parse(y.ToString())));
    int[,] result = new int[rJagged.Count(), rJagged.Max(x => x.Count())];
    for (int i = 0; i < rJagged.Count(); i++)
    {
        for (int j = 0; j < rJagged.ElementAt(i).Count(); j++)
        {
            result[i, j] = rJagged.ElementAt(i).ElementAt(j);
        }
    }
