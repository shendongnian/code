    public static IQueryable<Category> GetExpression(this IQueryable<Category> query)
    {
        var expression = qry.Include(cat => cat.InfoItems)
            .Include(cat => cat.Products)
                .ThenInclude(prd => prd.InfoItems)
            .Include(cat => cat.Products)
                .ThenInclude(prd => prd.GraphicItems)
                    .ThenInclude(itm => itm.Graphic)
                        .ThenInclude(gfx => gfx.Items)
            .Include(cat => cat.GraphicItems)
                .ThenInclude(gfx => gfx.Graphic)
                    .ThenInclude(gfx => gfx.Items)
            .Include(m => m.Modules);
        return expression;
    }
