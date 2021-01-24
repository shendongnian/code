    protected virtual ActionExecutedContext InvokeActionMethodWithFilters(ControllerContext controllerContext, IList<IActionFilter> filters, ActionDescriptor actionDescriptor, IDictionary<string, object> parameters)
    {
        ActionExecutingContext preContext = new ActionExecutingContext(controllerContext, actionDescriptor, parameters);
        Func<ActionExecutedContext> continuation = () =>
            new ActionExecutedContext(controllerContext, actionDescriptor, false /* canceled */, null /* exception */)
            {
                Result = InvokeActionMethod(controllerContext, actionDescriptor, parameters)
            };
        // need to reverse the filter list because the continuations are built up backward
        Func<ActionExecutedContext> thunk = filters.Reverse().Aggregate(continuation, (next, filter) => () => InvokeActionMethodFilter(filter, preContext, next));
        return thunk();
    }
