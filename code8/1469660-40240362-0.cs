    public class ConvenioViewModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ConvenioViewModel viewModel = new ConvenioViewModel() {};
            string jsonConvenio = bindingContext.ValueProvider.GetValue("convenio").AttemptedValue;
            JavaScriptSerializer jss = new JavaScriptSerializer();
            viewModel.Convenio = jss.Deserialize<Convenio>(jsonConvenio);
            return viewModel;
        }
    }
