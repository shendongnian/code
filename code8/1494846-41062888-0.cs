    try
    {
        // create object and save changes
        // EF will be throw a DbUpdateException if the insert fails
        // redirect to action
    }
    catch (DbUpdateException ex)
    {
        if (ExceptionHelper.IsUniqueConstraintViolation(ex))
        {
            ModelState.AddModelError("Name", $"The Name '{viewModel.Name}' is already in use, please enter a different name.");
            return View(nameof(CreateUser), viewModel);
        }
    }
