    public class CustomEqualityComparer : IEqualityComparer<object>
    {
        public new bool Equals(object x, object y)
        {
            if (x is Address && y is Address)
            {
                var xAddress = x as Address;
                var yAddress = y as Address;
                return xAddress.Line1 == yAddress.Line1 &&
                   xAddress.Line2 == yAddress.Line2 &&
                   xAddress.Line3 == yAddress.Line3 &&
                   xAddress.Line4 == yAddress.Line4;
            }
            if (x is Person && y is Person)
            {
                var xPerson = x as Person;
                var yPerson = y as Person;
                return xPerson.FirstName == yPerson.FirstName &&
                   xPerson.LastName == yPerson.LastName;
            }
            return false;
        }
        public int GetHashCode(object obj)
        {
            if (obj is Address)
            {
                var address = obj as Address;
                return  address.Line1.GetHashCode() ^
                        address.Line2.GetHashCode() ^
                        address.Line3.GetHashCode() ^
                        address.Line4.GetHashCode();
            }
            if (obj is Person)
            {
                var person = obj as Person;
                return person.FirstName.GetHashCode() ^
                       person.LastName.GetHashCode();
            }
            return obj.GetHashCode();
        }
    }
