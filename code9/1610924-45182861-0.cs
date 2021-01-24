    public class Utility
    {
        /// <summary>
        /// Copy one class all properties to another class - if both the class having all the same properties
        /// </summary>
        /// <param name="FromClass">Class A - from where properties need to be copied</param>
        /// <param name="ToClass">Class B - to whom properties need to be pasted</param>
        public static void CopyAllPropertiesFromOneClassToAnotherClass(object FromClass, object ToClass)
        {
            foreach (PropertyInfo propA in FromClass.GetType().GetProperties())
            {
                PropertyInfo propB = ToClass.GetType().GetProperty(propA.Name);
                propB.SetValue(ToClass, propA.GetValue(FromClass, null), null);
            }
        }
    }
