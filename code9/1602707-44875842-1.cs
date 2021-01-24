    var actionBlocks = GetControllerBlocks();
    //Flatten the collection of block.
    List<Entity> controllerActions = actionBlocks
        .SelectMany(b => b.ControllerActions
            .Select(a => new Entity { 
                ControllerName = b.ControllerName, 
                ActionName = a.ActionName 
             })
         )
        .ToList();
