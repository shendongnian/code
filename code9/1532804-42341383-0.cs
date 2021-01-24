    Mapper.Initialize(cfg => cfg.CreateMap<Category, CategoryModel>()); // move to app start
    var model = new CategoryViewModel();
    var category = _CategoryService.CategoryByID(id);
    model.CategoryModel = Mapper.Map<CategoryModel>(category);
    var categories = _CategoryService.GetAllCategory();
    model.List = Mapper.Map<IEnumerable<CategoryModel>>(categories);
