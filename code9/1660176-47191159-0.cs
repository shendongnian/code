     foreach (ProductCategoryMapItem catMap in cats)
           {
               var xCategory = new XElement(bv + "Category",
                   new XElement(bv + "ExternalId", catMap.ProductCategoryId),
                   new XElement(bv + "Name", catMap.Description.Title));
               xCategories.Add(xCategory);
               if (catMap.Children.Count > 0)
               {
                   foreach (ProductCategoryMapItem subcat in catMap.Children)
                   {
                       var xSubCategory = new XElement(bv + "Category",
                       new XElement(bv + "ExternalId", subcat.ProductCategoryId),
                       new XElement(bv + "ParentExternalId", subcat.ParentProductCategoryId),
                       new XElement(bv + "Name", subcat.Description.Title));
                       xCategories.Add(xSubCategory);
                       if(subcat.Children.Count > 0 )
                       {
                           foreach(ProductCategoryMapItem subsubcat in subcat.Children)
                           {
                                var xSubSubCategory = new XElement(bv + "Category",
                                new XElement(bv + "ExternalId", subsubcat.ProductCategoryId),
                                new XElement(bv + "ParentExternalId",subsubcat.ParentProductCategoryId),
                                new XElement(bv + "Name", subsubcat.Description.Title));
                                xCategories.Add(xSubSubCategory);
                           }
                       }
                   }
               }
           }
