    double[][] inputs = new double[][]
    {
        //      Wine | Price | Sugar | Alcohol | Acidity
        new double[] {   7,     7,      13,        7 },
        new double[] {   4,     3,      14,        7 },
        new double[] {  10,     5,      12,        5 },
        new double[] {  16,     7,      11,        3 },
        new double[] {  13,     3,      10,        3 },
    };
    
    double[][] outputs = new double[][]
    {
        //             Wine | Hedonic | Goes with meat | Goes with dessert
        new double[] {           14,          7,                 8 },
        new double[] {           10,          7,                 6 },
        new double[] {            8,          5,                 5 },
        new double[] {            2,          4,                 7 },
        new double[] {            6,          2,                 4 },
    };
    
    // Create the Partial Least Squares Analysis
    var pls = new PartialLeastSquaresAnalysis()
    {
        Method = AnalysisMethod.Center,
        Algorithm = PartialLeastSquaresAlgorithm.SIMPLS, // First change: use SIMPLS
    };
    
    // Learn the analysis
    pls.Learn(inputs, outputs);
    
    // Second change: Use just 1 latent factor/component
    var regression = pls.CreateRegression(factors: 1);
    
    // Third change: present results as in MATLAB
    double[][] w = regression.Weights.Transpose();
    double[] b = regression.Intercepts;
    
    // Add the intercepts as the first column of the matrix of
    // weights and transpose it as in the way MATLAB presents it
    double[][] coeffs = (w.InsertColumn(b, index: 0)).Transpose();
    
    // Show results in MATLAB format
    string str = coeffs.ToOctave();
