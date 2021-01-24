	public class TagHelper
    {
		public static readonly BindableProperty TagProperty =
			BindableProperty.Create("Tag", typeof(object), typeof(TagHelper), default(object));
		public static object GetTag(BindableObject bindable)
		{
			return (object)bindable.GetValue(TagProperty);
		}
		public static void SetTag(BindableObject bindable, object value)
		{
			bindable.SetValue(TagProperty, value);
		}
	}
