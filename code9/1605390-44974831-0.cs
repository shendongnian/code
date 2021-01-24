    var productsNormalized = productoSSOs.Aggregate((p,c) => {
        var product = new Produto
        {
            CodigoPeca = c.CodigoPeca,
            CodigoFamilia = c.CodigoFamilia,
            Familia = c.Familia,
            Peca = c.Peca
        };
        var service = new ProdutoServico
        {
            CodigoServico = c.CodigoServico,
            Hash = c.Hash,
            Servico = c.Servico,
            Valor = c.Valor
        };
        if (!p.ContainsKey(product)) 
        {
            p[product] = new List<ProductoServico>() { service };
        } 
        else
        {
            p[product].Add(service);
        }
    }, new Dictionary<Produto,List<ProdutoServico>>(ProductoComparer));
