		[ContentProperty("Content")]
		public class Fragment : FrameworkElement
		{
			private static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(FrameworkContentElement), typeof(Fragment));
			public FrameworkContentElement Content
			{
				get
				{
					return (FrameworkContentElement)GetValue(ContentProperty);
				}
				set
				{
					SetValue(ContentProperty, value);
				}
			}
		}
