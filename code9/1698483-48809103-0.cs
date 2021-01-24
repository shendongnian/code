    @using Nop.Core.Infrastructure;
    @using Nop.Core;
    @using Nop.Core.Domain.Customers;
    
    
    @{
        var _workContext = EngineContext.Current.Resolve<IWorkContext>();
        var isUserAdmin = _workContext.CurrentCustomer.IsAdmin();
    }
    
    @if(isUserAdmin)
    {
    //your code
    }
