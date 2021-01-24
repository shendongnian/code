    var formName = uow.Repository<MainMenu>()
                   .GetAll()
                   .Where(x => x.MenuId == getMenuId && x.IsVisible == 1)
                   .Select(x => x.FormName)
                   .FirstOrDefault();
    if(formName != null ) 
     {
       //TODO
     }
