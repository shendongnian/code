    public class MyGroupingDescription : PropertyGroupDescription
    {
        public override bool NamesMatch(object groupName, object itemName)
        {
            if((groupName as MyClass).OtherProperty == null && (itemName as MyClass).OtherProperty==null)
            {
                return true;
            }
            return false;
        }
    }
