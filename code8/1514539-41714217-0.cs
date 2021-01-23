    @{
        var descriptor = new ReflectedControllerDescriptor(this.ViewContext.Controller.GetType());
        var actions = descriptor.GetCanonicalActions();
    }
    
    @foreach (var action in actions)
    {
        <div>
            @Html.ActionLink("click me", action.ActionName)
        </div>
    }
