    using System.Web.Mvc;
    public class CustomModelMetaDataProvider : DataAnnotationsModelMetadataProvider {
    
        // called once for each property of the ViewModel
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName) {
    
            Func<IEnumerable<Attribute>, ModelMetadata> metadataFactory = attr => base.CreateMetadata(attr, containerType, modelAccessor, modelType, propertyName);
            var metadata = metadataFactory(attributes);
    
            // set DisplayName depending on ViewModel type and property name
            if (modelType == typeof(CustomModelToOverride)) {
                if (propertyName == "FirstName") {
                    metadata.DisplayName = "First name";
                }
                else if (propertyName == "LastName") {
                    // ...
                }
            }
         
            return metadata;
        }
    }
