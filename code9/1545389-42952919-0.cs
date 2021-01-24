    public class CmsModelBinder : DefaultModelBinder
    {
        protected override bool OnModelUpdating(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // Copy CmsEntities from Controller to the Model (Before we update and validate the model)
            var modelPropertyInfo = bindingContext.Model.GetType().GetProperty("CmsEntities");
            if (modelPropertyInfo != null)
            {
                var controllerPropertyInfo = controllerContext.Controller.GetType().GetProperty("CmsEntities");
                if (controllerPropertyInfo != null)
                {
                    CmsEntities cmsEntities = controllerPropertyInfo.GetValue(controllerContext.Controller) as CmsEntities;
                    modelPropertyInfo.SetValue(bindingContext.Model, cmsEntities);
                }
            }            
            return base.OnModelUpdating(controllerContext, bindingContext);
        }
