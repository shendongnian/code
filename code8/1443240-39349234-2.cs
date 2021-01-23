    try
    {
        if (ModelState.IsValid) { 
            if (model is ITraceableEntity)
            {
               ((ITraceableEntity)model).CreatedBy =  _myService.Username;  // <---
               ((ITraceableEntity)model).CreatedDate = DateTime.Now;        // <---
            }
            _repository.Update(model);
            await _repository.Save();
        }
    }
    catch (Exception)
    {
        ModelState.AddModelError(string.Empty, "Unable to save changes.");
    }
    return View(model);
