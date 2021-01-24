    public class MonthlyRevenues : ObservableCollection<DailyRevenues>, ITypedList
    {
        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            if(Count > 0)
            {
                return TypeDescriptor.GetProperties(this[0]);
            }
            else
            {
                return TypeDescriptor.GetProperties(typeof(DailyRevenues));
            }
        }
        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "Monthly Revenues";
        }
    }
