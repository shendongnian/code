    public class MyAttribute : Attribute
    {
        public string Display { get; set; }
        public MyAttribute([CallerMemberName] string propertyName = null)
        {
            Display = ((DisplayNameAttribute)GetCustomAttribute(typeof(Test).GetMember(propertyName).First(), typeof(DisplayNameAttribute))).DisplayName;
        }
    }
