    public class UserViewTagHelper : TagHelper
    {
        [ViewContext]
        public ViewContext ViewContext { get; set; }
        [ViewComponentContext]
        public ViewComponentContext ViewComponentContext { get; set;
    }
