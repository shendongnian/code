     public override void OnActionExecuted(ActionExecutedContext context)
     {
         sw.Stop();
         foreach (var filterDescriptor in context.ActionDescriptor.FilterDescriptors)
         {
             if (filterDescriptor.Filter is PerformanceLoggingExpectedMaxAttribute)
             {
                 var expectedMaxAttribute = filterDescriptor.Filter as PerformanceLoggingExpectedMaxAttribute;
                 if (expectedMaxAttribute != null) ExpectedMax = expectedMaxAttribute.ExpectedMax;
                 break;
             }
         }
         if (sw.ElapsedMilliseconds >= ExpectedMax)
         {
             _logger.LogInformation("Test log from PerformanceLoggingActionFilter");
         }
     }
