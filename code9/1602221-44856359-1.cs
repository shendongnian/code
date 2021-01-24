    public abstract class Activity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public ActivityType ActivityType { get; private set; } // consider to use enum
        public Activity(ActivityType activityType)
        {
            ActivityType = activityType;
        }
        public Activity(object[] values)
        {
            if (values.Length < 4)
                throw new ArgumentException();
            this.Id = getInt(values[0]);
            this.PersonId = getInt(values[1]);
            this.ActivityType = getActivityType(values[2]);
        }
        protected int getInt(object value)
        {
            if (!(value is int))
            {
                throw new ArgumentException();
            }
            return (int)value;
        }
        protected string getString(object value)
        {
            if (!(value is string))
            {
                throw new ArgumentException();
            }
            return (string)value;
        }
        protected decimal getDecimal(object value)
        {
            if (!(value is decimal))
            {
                throw new ArgumentException();
            }
            return (decimal)value;
        }
        protected ActivityType getActivityType(object value)
        {
            ActivityType result;
            if(value is string)
            {
                if (!Enum.TryParse((string)value, out result))
                {
                    throw new ArgumentException();
                }
            }
            else if(value is ActivityType)
            {
                result = (ActivityType)value;
            }
            else
            {
                throw new ArgumentException();
            }
            return result;
        }
    }
