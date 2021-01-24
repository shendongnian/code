            var query = from s in YourDbContext.DbSet<ProductSKU>
                join voc in YourDbContext.DbSet<ProductVariantOptionCombination> on s.SkuID equals voc.SkuID
                join vo in YourDbContext.DbSet<ProductVariantOption> on voc.VariantOptionID equals vo.VariantOptionID
                join v in YourDbContext.DbSet<ProductVariant> on vo.VariantID equals v.VariantID
                group new {s,voc, vo, v} by s.Price
                into g
                select new
                {
                    Price = g.Key,
                    Size = g.Max(x => x.v.Name == "Size" ? x.vo.VariantOptionName : ""),
                    Color = g.Max(x => x.v.Name == "Color" ? x.vo.VariantOptionName : ""),
                    Material = g.Max(x => x.v.Name == "Material" ? x.vo.VariantOptionName : "")
                };
