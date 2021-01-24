    public class TypedList<T> : List<T>, ITypedList, IList
        where T : ICustomTypeDescriptor
    {
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if (this.Any())
            {
                return this[0].GetProperties();
            }
            return new PropertyDescriptorCollection(new PropertyDescriptor[0]);
        }
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return null;
        }
    }
