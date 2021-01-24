    public async Task<Product> Create(Product entity)
    {
        var product = _repositoryProduct.FirstOrDefault(x => x.Id == entity.Id);
        if (product != null)
        {
            throw new UserFriendlyException("Product already exists.");
        }
        else
        {
            return await _repositoryProduct.InsertAsync(entity);
        }
    }
