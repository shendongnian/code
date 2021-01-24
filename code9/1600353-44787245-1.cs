    var parameters = ((IEnumerable<dynamic>)Data).Select(x =>
    {
        var p = new DynamicParameters(x);
        p.AddDynamicParams(new {Bax = 7});
        return p;
    });
