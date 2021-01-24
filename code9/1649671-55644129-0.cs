    System.Numerics.Tensors.SparseTensor<double> GetNodeSrcRow3(string text)
    {
        // A quick NuGet System.Numerics.Tensors Install:
        System.Numerics.Tensors.SparseTensor<double> SparseTensor = new System.Numerics.Tensors.SparseTensor<double>(new int[] { cpaths.Count }, true, 1);
        Parallel.For(1, cpaths.Count, (i, state) =>
        {
            if (cpaths[i].src == nodeName) SparseTensor[i] = 1.0D;
        });
        return SparseTensor;
    }
