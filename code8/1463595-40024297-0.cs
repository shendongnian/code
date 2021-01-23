    public class Foo {
        public static readonly BindableProperty TagProperty = BindableProperty.Create("Tag", typeof(string), typeof(Foo), null);
        public static string GetTag(BindableObject bindable)
        {
            return (string)bindable.GetValue(TagProperty);
        }
        public static void SetTag(BindableObject bindable, string value)
        {
            bindable.SetValue(TagProperty, value);
        }
    }
