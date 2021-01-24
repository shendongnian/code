    public virtual async Task<IHttpActionResult> Put(string id, [FromBody] TDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var entity = _dataContext.GetRepository<T>().GetById(id);
        if (entity == null)
            return NotFound();
        var entityToUpdate = _mapper.Map<T>(model);
		entityToUpdate = _mapper.Map<T, T>(entityToUpdate, entity);		
        var updatedEntity = _dataContext.GetRepository<T>().Update(entityToUpdate);
        var updatedEntityDto = _mapper.Map<TDto>(updatedEntity);
        return Ok(updatedEntityDto);
    }
