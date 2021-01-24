    private List<Product> _LocalizedProductList = new List<Product>();
    public List<Product> LocalizedProductList
        {
            get
            {
                HttpUtilities HttpHelper = new HttpUtilities();
                string culture = HttpHelper.getFullCulture();
                int IsoCode = GenericUtilities.getIsoID(culture, db);
                List<Product> localized = new List<Product>();
                foreach (Product p in _LocalizedProductList)
                {
                    foreach (CategoryTrans c in p.Category.CategoryTrans)
                    {
                        if (c.language_id.Equals(IsoCode))
                        {
                            Product x = new Product
                            {
                                ID = p.ID,
                                LocalizedCategoryName = c.name,
                                DateCreated = p.DateCreated,
                                DateExpire = p.DateExpire,
                                DateLastModified = p.DateLastModified,
                                Name = p.Name,
                                Description = p.Description,
                                IsApproved = p.IsApproved,
                                IsDeleted = p.IsDeleted,
                                ProductImages = p.ProductImages,
                                User = p.User
                            };
                            localized.Add(x);
                        };
                    }
                }
                return localized;
            }
            set { _LocalizedProductList = value; }
        }
