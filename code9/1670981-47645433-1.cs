    public class FooModelBinder : IModelBinder
    {
      private readonly IModelBinder worker;
      public FooModelBinder(IModelBinder worker)
      {
        this.worker = worker;
      }
      public  async Task BindModelAsync(ModelBindingContext bindingContext)
      {
        await this.worker.BindModelAsync(bindingContext);
        if (!bindingContext.Result.IsModelSet)
        {
          return;
        }
        var foo = bindingContext.Result.Model as Foo;
        if (foo == null)
        {
          throw new InvalidOperationException($"Expected {bindingContext.ModelName} to have been bound by ComplexTypeModelBinder");
        }
        // NOW DO SOME INTERESTING POST-PROCESSING
      }
    }
