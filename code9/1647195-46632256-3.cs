    var sb = new StringBuilder(string.Empty);
    var maxI = a.GetLength(0);
    var maxJ = a.GetLength(1);
    for (var i = 0; i < maxI; i++)
    {
        sb.Append("{");
        for (var j = 0; j < maxJ; j++)
        {
            sb.Append($"{a[i, j]},");
        }
        sb.Append("},");
    }
    sb.Insert(0, "{").Append("}").Replace(",}", "}");
