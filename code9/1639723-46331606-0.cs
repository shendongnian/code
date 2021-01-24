    public object Evaluate(string exprString, object o)
    {
        var dict = o.GetType().GetProperties().ToDictionary(p => p.Name, p => p);
        var expr = new NCalc.Expression(exprString);
        expr.EvaluateParameter += (name, e) =>
        {
            e.Result = dict[name].GetValue(o, null);
        };
        return expr.Evaluate();
    }
-----
    var res = Evaluate(
                 "productId = '100' and (GUID = '100' or (GUID = '200' and productId = '100' ) )", 
                 new { productId = "100", GUID = "100" });
