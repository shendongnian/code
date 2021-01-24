    using System;
    using System.Web.Http.Controllers;
    using System.Web.Http.ModelBinding;
    public class FooModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Foo))
                return false;
            var foo = new Foo();
            var time = bindingContext.ValueProvider.GetValue("time");
            if (time != null)
                foo.time = DateTime.Parse(time.AttemptedValue.Replace(".", ":"));
            bindingContext.Model = foo;
            return true;
        }
    }
