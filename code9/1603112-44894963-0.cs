    //for actions with AuthorizeAttribute
    var actions = asm.GetTypes()
                .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(m => m.GetCustomAttributes(typeof(System.Web.Mvc.AuthorizeAttribute), true).Any())
                .Select(x => new { Controller = x.DeclaringType.Name.Replace("Controller", string.Empty), Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
                .OrderBy(x => x.Controller).ThenBy(x => x.Action);
    
    //for controllers with AuthorizeAttribute
    var controllers = asm.GetTypes()
                .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
                .Select(type => type.GetTypeInfo())
                .Where(type => type.GetCustomAttributes(typeof(System.Web.Mvc.AuthorizeAttribute), true).Any())
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(m => !m.GetCustomAttributes(typeof(System.Web.Mvc.AllowAnonymousAttribute), false).Any())
                .Select(x => new { Controller = x.DeclaringType.Name.Replace("Controller", string.Empty), Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
                .OrderBy(x => x.Controller).ThenBy(x => x.Action);
    
    var controlleractionlists = actions.Concat(controllers).ToList();
