    Parallel.ForEach(
        lstMaterialComposition,
        new ParallelOptions { MaxDegreeOfParallelism = 10 },
        composition => { 
                try
                {
                    CalculateAccuracy(composition);
                }
                catch (Exception ex)
                {
                    //LogException(ex)
                }
         }
    );
