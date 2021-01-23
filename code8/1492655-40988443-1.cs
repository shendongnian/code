    using System;
    
    namespace ServiceTest
    {
        public class Service : IService
        {
            public string TestMethod(ServiceDto dto)
            {
                if (dto == null)
                    throw new ArgumentNullException("dto");
    
                var properties = typeof(ServiceDto).GetProperties();
    
                foreach (var property in properties)
                {
                    var attributes = property.GetCustomAttributes(true);
                    foreach (var attribute in attributes)
                    {
                        var dtoPropAtt = attribute as DtoPropertyAttribute;
                        if (dtoPropAtt != null)
                        {
                            return string.Format("Maximum Length is: '{0}'!" ,dtoPropAtt.MaximumLength);
                        }
                    }
                }
    
                return "Attribute Serialization Test Failed";
            }
        }
    }
