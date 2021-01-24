    public class DailyRevenues : ICustomTypeDescriptor
    {
        public int ShopId { get; set; }
        public int Day { get; set; }
        public ObservableCollection<Department> DepartmentList { get; set; }
        public DailyRevenues()
        {
            this.DepartmentList = new ObservableCollection<Department>();
        }
        public decimal TotalOfDepartments { get;  }
        public decimal CashTotal { get;  }
        public decimal CreditTotal { get; }
        public AttributeCollection GetAttributes()
        {
            return new AttributeCollection();
        }
        public string GetClassName()
        {
            return "DailyRevenues";
        }
        public string GetComponentName()
        {
            return "";
        }
        public TypeConverter GetConverter()
        {
            return null;
        }
        public EventDescriptor GetDefaultEvent()
        {
            return null;
        }
        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }
        public object GetEditor(Type editorBaseType)
        {
            return null;
        }
        public EventDescriptorCollection GetEvents()
        {
            return null;
        }
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return null;
        }
        public PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection pdc0 = TypeDescriptor.GetProperties(typeof(DailyRevenues));
            List<PropertyDescriptor> pdList = new List<PropertyDescriptor>();
            pdList.Add(pdc0["Day"]);
            for (int i = 0; i < DepartmentList.Count; ++i)
            {
                pdList.Add(new DailyRevenuesProperty(DepartmentList[i].Name, i));
            }
            pdList.Add(pdc0["TotalOfDepartments"]);
            pdList.Add(pdc0["CashTotal"]);
            pdList.Add(pdc0["CreditTotal"]);
            return new PropertyDescriptorCollection(pdList.ToArray());
        }
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
    }
