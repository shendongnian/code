		public class ButtonWithIcon : Button
		{
			public static readonly DependencyProperty IconContentProperty =
				DependencyProperty.Register("IconContent", typeof(string), typeof(ButtonWithIcon), new PropertyMetadata(default(Icon)));
			public string IconContent
			{
				get => (string)GetValue(IconContentProperty);
				set => SetValue(IconContentProperty, value);
			}
		}
