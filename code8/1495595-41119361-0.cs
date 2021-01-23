    public static Tuple<double, double, double> performLinearRegression(Series<double, double> series)
    {
        REngine.SetEnvironmentVariables();
        REngine engine = REngine.GetInstance();
        engine.Initialize();
        var x = engine.CreateNumericVector(series.Keys);
        var y = engine.CreateNumericVector(series.Values);
        engine.SetSymbol("x", x);
        engine.SetSymbol("y", y);
        var result = engine.Evaluate("lm(y~x)");
        engine.SetSymbol("result", result);
        var coefficients = result.AsList()["coefficients"].AsNumeric().ToList();
        double r2 = engine.Evaluate("summary(result)").AsList()["r.squared"].AsNumeric().ToList()[0];
        double intercept = coefficients[0];
        double slope = coefficients[1];
        return Tuple.Create(intercept, slope, r2);
    }
