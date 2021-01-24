    private Func<Foo, bool> GetExpression(string param, string searchTerm)
    {
        switch (param)
        {
            case "bar":
                return f => f.Bar.Contains(searchTerm);
            case "baz":
                return f => f.Baz.Contains(searchTerm);
            // ...
        }
    }
