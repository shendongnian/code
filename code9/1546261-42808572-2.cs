    public class ArrayModelBinder: DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var rawArray = controllerContext.HttpContext.Request.QueryString["SuchObject"];
            var array = JsonConvert.DeserializeObject<IEnumerable<MyObject>>(rawArray);
            return array;
        }
    }
