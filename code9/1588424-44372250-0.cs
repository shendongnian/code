    public class CustomModelBinder : DefaultModelBinder
    {
        static Assembly _assembly = typeof(CustomModelBinder).Assembly;
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {   
            if (_assembly.Equals(bindingContext.ModelType.Assembly))
            {
                var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
                var ctor = bindingContext.ModelType.GetConstructor(new Type[] { typeof(string) });
                if (ctor != null && value != null)
                    return ctor.Invoke(new object[] { value.AttemptedValue });
            }
            return base.BindModel(controllerContext, bindingContext);
        }
    }
