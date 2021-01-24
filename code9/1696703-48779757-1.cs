    public class CategoryRecipeIndexViewModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        [Display(Name = "Category")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Descr { get; set; }
        public ICollection<CategoryRecipeIndexViewModel> Category1 { get; set; }
        public ICollection<RecipeIndexViewModel> Recipes { get; set; }
    }
    public class RecipeIndexViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Recipe")]
        public string Title { get; set; }
        [Display(Name = "Description")]
        public string Descr { get; set; }
        public double Yield { get; set; }
        public ICollection<UserRecipeIndexViewModel> UserRecipes { get; set; }
	    [Display(Name = "Yield")]
        public string UserYieldUnit
        {
            get
            {
                return System.String.Format("{0} {1}", ((Yield * 
							UserRecipes.FirstOrDefault().MeasUnitSystem.MeasUnitConv.UnitBaseConvDiv / 
							UserRecipes.FirstOrDefault().MeasUnitSystem.MeasUnitConv.UnitBaseConvMult) - 
							UserRecipes.FirstOrDefault().MeasUnitSystem.MeasUnitConv.UnitBaseConvOffset).ToString("n1"),
						    UserRecipes.FirstOrDefault().MeasUnitSystem.MeasUnit.MeasUnitSymbols.FirstOrDefault().Symbol);
            }
        }
    }
    public class UserRecipeIndexViewModel
    {
        public MeasUnitSystemIndexViewModel MeasUnitSystem { get; set; }
    }
    public class MeasUnitSystemIndexViewModel
    {
        public MeasUnitIndexViewModel MeasUnit { get; set; }
        public MeasUnitConvIndexViewModel MeasUnitConv { get; set; }
    }
    public class MeasUnitIndexViewModel
    {
        public ICollection<MeasUnitSymbolIndexViewModel> MeasUnitSymbols { get; set; }
    }
    public class MeasUnitConvIndexViewModel
    {
        public double UnitBaseConvMult { get; set; }
        public double UnitBaseConvDiv { get; set; }
        public double UnitBaseConvOffset { get; set; }
    }
    public class MeasUnitSymbolIndexViewModel
    {
        public string Symbol { get; set; }
    }
