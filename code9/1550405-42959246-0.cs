    public class SubTypeList : List<System.Type>
    {
        public System.Type BaseType { get; set; }
        public SubTypeList()
            : this(typeof(System.Object))
        {
        }
        public SubTypeList(System.Type baseType)
        {
            BaseType = BaseType;
        }
        public new void Add(System.Type item)
        {
            if (item.IsSubclassOf(BaseType) == true)
            {
                base.Add(item);
            }
            else
            {
                // handle error condition where it's not a subtype... perhaps throw an exception if
            }
        }
    }
