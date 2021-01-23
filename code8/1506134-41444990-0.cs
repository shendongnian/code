    public class NotNullListBinder : DefaultModelBinder
        {
    
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                if (bindingContext.ModelType == typeof(MyViewModel))
                {
                    var result = base.BindModel(controllerContext, newBindingContext);
                    if(result != null && result.MyList == null)
                     {
                        result.MyList = new new List<MyItem>();
                        return result;
                      }
                }
                else
                {
                    return base.BindModel(controllerContext, bindingContext);
                }
            }
    
        }
