    public class Globals
    {
        public InsuredItem _i;
        public decimal SumAssured;
    }
    …
    string formula = "(_i.PremiumRate/100)*SumAssured";
    var script = CSharpScript.Create<decimal>(formula, globalsType: typeof(Globals))
        .CreateDelegate();
    foreach (InsuredItem _i in p.InsuredItems)
    {
        _i.Premium = await script(new Globals { _i = _i, SumAssured = SumAssured });
    }
