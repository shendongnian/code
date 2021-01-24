    class DiaperBrandClass {   
        public string BrandName;
        public int BrandLevelNumber;
        public DiaperBrandClass(string brandName, int brandLevel)
        {
            this.BrandName = brandName;
            this.BrandLevelNumber = brandLevel;
        }
    }
    class DiaperSizeClass {
        public int SizeLevelNumber;
        public string SizeDescription;      // This could be made an enum
        public float BasePrice;
        public Dictionary<int, float> Discounts;
        public DiaperSizeClass(int sizeLevel, float basePrice, Dictionary<int, float> discounts)
        {
            this.SizeLevelNumber = sizeLevel;
            this.BasePrice = basePrice;
            this.Discounts = discounts;
        }
    }
    class DiaperBrandLevelClass {
        public DiaperSizeClass[] DiaperSizes;
        public DiaperBrandLevelClass(DiaperSizeClass[] diaperSizes)
        {
            this.DiaperSizes = diaperSizes;
        }
    }
