    using System.Threading.Tasks;
    namespace Microsoft.AspNetCore.Mvc.ModelBinding
    {
        //
        // Summary:
        //     Defines an interface for model binders.
        public interface IModelBinder
        {
            //
            // Summary:
            //     Attempts to bind a model.
            //
            // Parameters:
            //   bindingContext:
            //     The Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.
            //
            // Returns:
            //     A System.Threading.Tasks.Task which will complete when the model binding process
            //     completes.
            //     If model binding was successful, the Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.Result
            //     should have Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.IsModelSet
            //     set to true.
            //     A model binder that completes successfully should set Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingContext.Result
            //     to a value returned from Microsoft.AspNetCore.Mvc.ModelBinding.ModelBindingResult.Success(System.Object).
            Task BindModelAsync(ModelBindingContext bindingContext);
        }
    }
