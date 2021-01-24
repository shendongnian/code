    public class ItemModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var values = (ValueProviderCollection) bindingContext.ValueProvider;
            var itemId = (int) values.GetValue("ItemId").ConvertTo(typeof (int));
            var objectStateId = (int?) values.GetValue("ObjectStateId").ConvertTo(typeof(int));
            //Make desicion and create the real type instance Appointment, AppointedActivity or AppointedDevice
            return (Item) new Appointment { ItemId= itemId, ObjectStateId = objectStateId };
        }
    }
