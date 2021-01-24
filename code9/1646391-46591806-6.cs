         public async Task<SimplePagedResult<TEntityDto>> GetAllPagedAsync<TEntityDto>(PagingSettins request) where TEntityDto : class
        {
            var projectTo = Set(); // Here is DBSet<TEnitity>
            var entityDtos = projectTo.OrderByField(new SortingSettings());
            if (request.PagingSettings != null)
                entityDtos = entityDtos.ToPage(request.PagingSettings);
            var resultItems = await entityDtos.ToListAsync();
            var result = MakeSimplePagedResult(request.PagingSettings, resultItems);
            return result;
        }
