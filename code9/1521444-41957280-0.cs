    var query = this.context.Blocks.Where(o =>
                            o.IsActive && o.ProductSizes.Any(x =>
                            x.SectionProductSizes.Any(y =>
                            && y.SectionID == queryCriteria.SectionId y.Section.SizeTypeID == o.SizeTypeID
                            )
                          )
                        ).OrderBy(x => x.SectionProductSizes.DisplayOrder); 
