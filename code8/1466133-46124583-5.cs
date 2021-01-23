    /// <inheritdoc />
    /// <summary>
    /// Form File Model binder
    /// Parses the Form file object type to a commonFile
    /// </summary>
    public class FormFileModelBinder : IModelBinder
    {
        /// <summary>
        /// Expression to map IFormFile object type to CommonFile
        /// </summary>
        private readonly Func<Microsoft.AspNetCore.Http.IFormFile, ICommonFile> _expression;
        /// <summary>
        /// FormFile Model binder constructor
        /// </summary>
        public FormFileModelBinder()
        {
            _expression = x => new CommonFile(x.OpenReadStream(), x.Length, x.Name, x.FileName);
        }
        /// <inheritdoc />
        ///  <summary>
        ///  It Binds IFormFile to Common file, getting the file
        ///  from the binding context
        ///  </summary>
        ///  <param name="bindingContext">Http Context</param>
        ///  <returns>Completed Task</returns>
        // TODO: Bind this context to ICommonFile or ICommonFileCollection object
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            dynamic model;
            if (bindingContext == null) throw new ArgumentNullException(nameof(bindingContext));
            var formFiles = bindingContext.ActionContext.HttpContext.Request.Form.Files;
            if (!formFiles.Any()) return Task.CompletedTask;
            if (formFiles.Count > 1)
            {
                model = formFiles.AsParallel().Select(_expression);
            }
            else
            {
                model = formFiles.Select(_expression).First();
            }
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
