    public class LocalizedDataAnnotationsModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var meta = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);  //  Get metadata of the property
            string resXKey = string.Empty;
            object attribute = attributes.OfType<DisplayLabel>().FirstOrDefault();  //  Try to get the DisplayLabel annotation
            //  If DisplayLabel is found then...
            if (attribute != null)
            {
                resXKey = ((DisplayLabel)attribute).Key;    //  Grab the resx key added to the annotation
                meta.DisplayName = Application.GetLangResource(resXKey) + meta.DisplayName; //  Retrieve the language resource for the key and add back any trailing items returned by the annotation
            }
            //  DisplayLabel is not found...
            if (attribute == null)
            {
                attribute = attributes.OfType<DisplayNameLocalizedAttribute>().FirstOrDefault();    //  Try to get the DisplayNameLocalizedAttribute annotation
                //  If annotation exists then...
                if (attribute != null)
                {
                    resXKey = ((DisplayNameLocalizedAttribute)attribute).Key;   //  Grab the resx key added to the annotation
                    string resXValue = Application.GetLangResource(resXKey);    //  Retrieve the language resource for the key
                    string finalValue = resXValue;  //  Create a new string
                    if (((DisplayNameLocalizedAttribute)attribute).IsLabel) //  Check if property annotation is set to label
                    {
                        finalValue = resXValue + meta.DisplayName;  //  Add back any trailing items returned by the annotation
                    }
                    meta.DisplayName = finalValue;  //  Set the DisplayName of the property back onto the meta
                }
            }
            return meta;
        }
    } 
