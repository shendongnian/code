		public class BindableRun : Run
		{
			public static readonly DependencyProperty BoundTextProperty = DependencyProperty.Register("BoundText", typeof(string), typeof(BindableRun), new PropertyMetadata(OnBoundTextChanged));
			public BindableRun()
			{
				Helpers.FixupDataContext(this);
			}
			private static void OnBoundTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
			{
				((Run)d).Text = (string)e.NewValue;
			}
			public String BoundText
			{
				get { return (string)GetValue(BoundTextProperty); }
				set { SetValue(BoundTextProperty, value); }
			}
		}
