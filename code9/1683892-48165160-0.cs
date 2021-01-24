    public class MasterPageItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public MasterPageItem(string title, Type targetType)
        {
            Title = title;
            TargetType = targetType;
        }
    }
