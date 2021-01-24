	[ContentProperty("Content")]
	public class Definition : Element
	{
		public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(List<object>), typeof(Definition), null);
		public List<object> Content 
		{ 
			get { return (List<object>)GetValue(ContentProperty); } 
			set { SetValue(ContentProperty, value); }
		}
		public string Identifier {get; set; }
        public Definition()
        {
            Content = new List<object>();
        }
	}
