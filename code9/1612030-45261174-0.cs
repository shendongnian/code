    List<Ap21Style> results = products
        .GroupBy(p => new { p.StyleIdx, p.StyleCode })
        .Select(g => new Ap21Style {
            StyleIdx = g.Key.StyleIdx,
            StyleCode = g.Key.StyleCode,
            Clrs = g.GroupBy(s => new {
                s.ClrIdx,
                s.ColourCode,
                s.ColourName,
                s.ColourTypeCode,
                s.ColourTypeName
            }).Select(g1 => new Ap21Clr {
                ClrIdx = g1.Key.ClrIdx,
                ColourCode = g1.Key.ColourCode,
                ColourName = g1.Key.ColourName,
                ColourTypeCode = g1.Key.ColourTypeCode,
                ColourTypeName = g1.Key.ColourTypeName,
                Skus = g1.Select(s => new Ap21Sku {
                    Barcode = s.Barcode,
                    SizeCode = s.SizeCode,
                    SizeSequence = s.SizeSequence,
                    SkuIdx = s.SkuIdx
                }).ToList()
            }).ToList()
        }).ToList();
