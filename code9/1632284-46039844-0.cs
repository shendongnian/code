    //IActionDescriptorCollectionProvider provider
    var routes = provider.ActionDescriptors.Items.Select(x => new { 
               Action = x.RouteValues["Action"], 
               Controller = x.RouteValues["Controller"], 
               Name = x.AttributeRouteInfo.Name, 
               Template = x.AttributeRouteInfo.Template 
            }).ToList();
