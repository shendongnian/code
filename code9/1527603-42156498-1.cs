    public JsonResult Action(string foo)
    {
        if (ShouldProcessUsingMethod1(foo)) return Method1(foo);
        else return Method2(foo);
    }
    private JsonResult Method1(string foo) { ... }
    private JsonResult Method2(string foo) { ... }
    private bool ShouldProcessUsingMethod1(string foo) { ... }
