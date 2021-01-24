    // move next line to Application_Start
    Mapper.Initialize(cfg => cfg.CreateMap<Category, CategoryModel>());     
    var model = new CategoryViewModel();
    var category = _CategoryService.CategoryByID(id);
    model.CategoryModel = Mapper.Map<CategoryModel>(category);
    var categories = _CategoryService.GetAllCategory();
    model.List = Mapper.Map<IEnumerable<CategoryModel>>(categories);
