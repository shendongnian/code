    if (!string.IsNullOrWhiteSpace(whatToSearch))
    {
        //I've added call to ALL to fetch all products and then filter on 
        //code side. 
        products = UCommerce.EntitiesV2.Product.All().Where(p =>
                p.VariantSku == null && p.DisplayOnSite &&
                (
                    p.Sku.Contains(whatToSearch)
                    || p.Name.RemoveDiacritics().Contains(whatToSearch)
                    || p.ProductDescriptions.Any(
                        d => d.DisplayName.Contains(whatToSearch)
                             || d.ShortDescription.Contains(whatToSearch)
                             || d.LongDescription.Contains(whatToSearch)
                    )
                )
        );
    }
