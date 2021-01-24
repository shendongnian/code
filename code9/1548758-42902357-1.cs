    public static class ReportsSample
        {
    
    
            /// <summary>
            /// Returns the Analytics data. 
            /// Documentation https://developers.google.com/analyticsreporting/v4/reference/reports/batchGet
            /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
            /// </summary>
            /// <param name="service">Authenticated AnalyticsReporting service.</param>  
            /// <param name="body">A valid AnalyticsReporting v4 body.</param>
            /// <returns>GetReportsResponseResponse</returns>
            public static GetReportsResponse BatchGet(AnalyticsReportingService service, GetReportsRequest body)
            {
                try
                {
                    // Initial validation.
                    if (service == null)
                        throw new ArgumentNullException("service");
                    if (body == null)
                        throw new ArgumentNullException("body");
    
                    // Make the request.
                    return service.Reports.BatchGet(body).Execute();
                }
                catch (Exception ex)
                {
                    throw new Exception("Request Reports.BatchGet failed.", ex);
                }
            }
    
            
    	}
    		public static class SampleHelpers
        {
    
            /// <summary>
            /// Using reflection to apply optional parameters to the request.  
            /// 
            /// If the optonal parameters are null then we will just return the request as is.
            /// </summary>
            /// <param name="request">The request. </param>
            /// <param name="optional">The optional parameters. </param>
            /// <returns></returns>
            public static object ApplyOptionalParms(object request, object optional)
            {
                if (optional == null)
                    return request;
    
                System.Reflection.PropertyInfo[] optionalProperties = (optional.GetType()).GetProperties();
    
                foreach (System.Reflection.PropertyInfo property in optionalProperties)
                {
                    // Copy value from optional parms to the request.  They should have the same names and datatypes.
                    System.Reflection.PropertyInfo piShared = (request.GetType()).GetProperty(property.Name);
    				if (property.GetValue(optional, null) != null) // TODO Test that we do not add values for items that are null
    					piShared.SetValue(request, property.GetValue(optional, null), null);
                }
    
                return request;
            }
        }
