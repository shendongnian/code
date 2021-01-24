    @model IBaseModel
    @using (Html.BeginForm("Create", "Users", FormMethod.Post))
    {
        @Html.Partial("_CreateOrUpdate", IBaseModel)
    }
          
    
    // instead of this than all you need to do is cast to right model 
    @if(Model is ChildModel)
    {
        @model Models.ChildModel
    }
    else
    {
        @model Models.AnotherChildModel
    }
    
    // in this case you will be able use both types and if your base class is implementing it you don't have to do much of refactoring.
    IBaseModel as ChildModel.something 
    IBaseModel as AnotherChildModel.something  
