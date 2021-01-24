    public class MyViewLocator : IViewLocator {
       public MyViewModelLocator(Assembly viewAssembly, string viewNameSpace)
    ...
       private IViewFor AttemptViewResolutionFor(Type viewModelType, string contract)
        {
            // proposed view type is now based on provided namespace + classname as modified by ViewModelToViewFunc
            if (viewModelType == null) return null;
            var viewModelTypeName = viewModelType.Name;
            var proposedViewTypeName = _viewNamespace + "." +  this.ViewModelToViewFunc(viewModelTypeName);
    ...
       private IViewFor AttemptViewResolution(string viewTypeName, string contract)
        {
            try
            {
                // resolve view type in the assembly of the view, and not assembly of the viewmodel
                var viewType = _viewAssembly.GetType(viewTypeName); // instead of Reflection.ReallyFindType(viewTypeName, throwOnFailure: false);
    ...
    }
