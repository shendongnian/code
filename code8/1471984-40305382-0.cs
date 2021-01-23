    public class VM_News : M_News
    {
        public SelectList CategoriesList { get; set; }
        [Display(Name = "Categories")]
        public List<int> CategoriesListSelected { get; set; }
    }
        public IActionResult Create()
        {
            VM_News vm_News = new VM_News();
            var categoriesList =
                _context.
                db_Category.
                OrderBy(z => z.Title).
                Select(x => new { Id = x.IDCategory, Value = x.Title });
            vm_News.DateCreated = DateTime.Now;
            vm_News.IsActive = true;
            vm_News.CategoriesList = new SelectList(categoriesList, "Id", "Value");
            return View(vm_News);
        }
        public async Task<IActionResult> Create([Bind("IDNews,DateCreated,IsActive,Text,Title,CategoriesListSelected,OriginTitle,OriginUrl")] VM_News vm_News)
        {
            if (ModelState.IsValid)
            {
                M_News m_News = new M_News();
                m_News.Title = vm_News.Title;
                m_News.Text = vm_News.Text;
                m_News.IsActive = vm_News.IsActive;
                m_News.DateCreated = vm_News.DateCreated;
                m_News.OriginTitle = vm_News.OriginTitle;
                m_News.OriginUrl = vm_News.OriginUrl;
                foreach (var item in vm_News.CategoriesListSelected)
                {
                    M_CategoryNews MTM = new M_CategoryNews();
                    MTM.M_News = m_News;
                    M_Category category = _context.db_Category.SingleOrDefault(z => z.IDCategory == item);
                    MTM.M_Category = category;
                    _context.Add(MTM);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            var categoriesList =
                            _context.
                            db_Category.
                            OrderBy(z => z.Title).
                            Select(x => new { Id = x.IDCategory, Value = x.Title });
            vm_News.CategoriesList = new SelectList(categoriesList, "Id", "Value");
            return View(vm_News);
        }
		<form asp-action="Create">
			<div class="form-horizontal">
				<h4>M_News</h4>
				<hr />
				<div asp-validation-summary="ModelOnly" class="text-danger"></div>
				<div class="form-group">
					<label asp-for="CategoriesListSelected" class="col-md-1 control-   label"></label>
					<div class="col-md-11">
						<select asp-for="CategoriesListSelected" asp-items="@Model.CategoriesList" ></select>
						<span asp-validation-for="CategoriesListSelected" class="text-danger" />
					</div>
				</div>
