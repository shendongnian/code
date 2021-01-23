    public async Task<IHttpActionResult> getOne(int id) {
        var category = await _unitOfWork.Categories.GetSingleAsync(id);
        var categoryVm = Mapper.Map<Category, CategoryViewModel>(category);
        return Ok(categoryVm);
    }
