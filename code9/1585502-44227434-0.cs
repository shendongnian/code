    public CategoryTrans CategoryTrans
    {
        get
        {
            HttpUtilities HttpHelper = new HttpUtilities();
            string culture = HttpHelper.getShortCulture();
            var CT = Product.Category.CategoryTrans
            .FirstOrDefault(b => b.languageId.Equals(culture));
            return CT;
        }
      }
