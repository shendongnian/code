        List<double[]> matrixParams = new List<double[]>();
        foreach (var item in listMRInfoBuy.Elements)
        {
            matrixParams.Add(item.ListValuesBuy.ToArray());
        }
        var matrixArrayBuy = CreateMatrix.DenseOfColumnArrays(matrixParams);
