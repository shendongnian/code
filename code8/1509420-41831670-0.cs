     public class PTGIndexVM
    {
        [Display(Name="Select Promotion")]
        public int PromotionId { get; set; }
        public List<SelectListItem> PromotionOptions { get; set; }
        public IList<EditPTG> IndexList { get; set; }
        public IList<Product> Products { get; set; }
        public string wrapClass { get; set; }
        /// <summary>
        /// Members Setup
        /// </summary>
        public PTGIndexVM()
        {
            IndexList = new List<EditPTG>();
            PromotionOptions = new List<SelectListItem>();
            Products = new List<Product>();
            Setup();
        }
      vm.Products = productLogic
                .GetByAndInclude(x => x.PromotionID == PromotionId && x.WindowProduct == true && x.Active == true, new List<string>() { "Size", "ProductTemplate" })
                .Where(prod => allPTG.Any(x => x.ProductID == prod.ProductID))
                .OrderBy(prod => prod.ProductCode)
                .Select(prod => prod)
                .ToList();
     foreach (var product in Model.Products)
                        {
                        <th class="center-text" title="@product.ProductTemplate.Vertical (V) x @product.ProductTemplate.Horizontal (H)">
                            @Html.DisplayFor(m => product.ProductCode)
                        </th>
                        }
                    }
