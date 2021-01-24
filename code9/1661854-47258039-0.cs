    // Create new stub with correct id and attach to context.
    var classobj = new Test { Id = input.Id };
    repository.As<EfRepositoryBase<MyDbContext, Test>>().Table.Attach(classobj);
    // Now the entity is being tracked by EF, update required properties.
    classobj.TestCode = input.TestCode;
    classobj.TestName = input.TestName;
    classobj.TestDesc = input.TestDesc;
          
    // EF knows only to update the properties specified above.
    _unitOfWorkManager.Current.SaveChanges();
