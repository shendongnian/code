    public class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        public LocalizedDisplayNameAttribute(string displayNameKey)
            : base(displayNameKey)
        {
        }
        public override string DisplayName
        {
            get
            {
                // Get your string from db 
                // or load it from specific resource file 
                //(as your business) and return string;
            }
        }
    }
