	public class CircleLabel: NControlView
	{
		public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CircleLabel), default(string));
		public string Text {
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}
		protected Label _label;
		public CircleLabel()
		{
			_label = new Label() {
				TextColor = Xamarin.Forms.Color.White,
				VerticalOptions = LayoutOptions.Center,
				HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center
			};
			_label.BindingContext = this;
			_label.SetBinding(Label.TextProperty, "Text");
			// add the label to the ContentView
			Content = _label;
		}
		public override void Draw(NGraphics.ICanvas canvas, NGraphics.Rect rect)
		{
			base.Draw(canvas, rect);
			// draw an orange circle
			canvas.FillEllipse(rect, NGraphics.Colors.Orange);
		}
	}
