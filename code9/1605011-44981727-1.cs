    public class DailyRevenuesProperty : PropertyDescriptor
    {
        int _index;
        public DailyRevenuesProperty(string name, int index)
            : base(name, new Attribute[0])
        {
            _index = index;
        }
        public override Type ComponentType
        {
            get
            {
                return typeof(DailyRevenues);
            }
        }
        public override bool IsReadOnly
        {
            get
            {
                return true;
            }
        }
        public override Type PropertyType
        {
            get
            {
                return typeof(decimal);
            }
        }
        public override bool CanResetValue(object component)
        {
            return false;
        }
        public override object GetValue(object component)
        {
            DailyRevenues dr = component as DailyRevenues;
            if(dr != null && _index >= 0 && _index < dr.DepartmentList.Count)
            {
                return dr.DepartmentList[_index].Total;
            }
            else
            {
                return (decimal)0;
            }
        }
        public override void ResetValue(object component)
        {
        }
        public override void SetValue(object component, object value)
        {
        }
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
