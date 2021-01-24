    public class TimeModelBinder : DefaultModelBinder
            {
                public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
                {    
                    var model = (ReceiptClassifyDetailViewModel)base.BindModel(controllerContext, bindingContext);
                    var the12HrTime = controllerContext.HttpContext.Request["TempTimeOnVM"];
                    
                    if (!string.IsNullOrEmpty(the12HrTime))
                    {
                        DateTime t = DateTime.ParseExact(the12HrTime, "h:mm tt", CultureInfo.InvariantCulture);
                        TimeSpan? ts = t.TimeOfDay;
                        model.TheTime = ts;
                    }
                    
                    return model;
                }
            }
