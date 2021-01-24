    public class UserDetails
    {
        public string name{ get; set; };
        [ModelBinder(BinderType = typeof(ArabicDateTimeBinder))]
        public DateTime SyncTime{ get; set; };
    }
