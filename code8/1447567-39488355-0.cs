    public class NotNullStringModelBinder : DefaultModelBinder {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            bindingContext.ModelMetadata.ConvertEmptyStringToNull = false;
            return base.BindModel(controllerContext, bindingContext);
        }
    }
