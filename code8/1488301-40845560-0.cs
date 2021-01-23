    public class CustomControlOneConverter : TypeConverter {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            //By returning true, you tell the property designer to add a drop down list
            return true;
        }
    
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            //By returning true, you tell the property designer to not allow the user to enter his own text
            return true;
        }
    
    
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            //Get all objects of type CustomControlTwo from the container
            CustomControlTwo[] controlsToList =
                context.Container.Components.OfType<CustomControlTwo>().ToArray;
    
            //Return a collection of the controls
            return new StandardValuesCollection(controlsToList);
        }
        //implement the other abstract methods
    }
