    public class FancyButton : Button {
        /// <summary>
        /// The color pressed down color property.
        /// </summary>
        public static readonly BindableProperty PressedDownColorProperty = BindableProperty.Create(nameof(PressedDownColor), typeof(Color), typeof(FancyButton), default(Color));
        /// <summary>
        /// Gets or sets the pressed down color.
        /// </summary>
        /// <value>The color to change to when the button is pressed down string.</value>
        public Color PressedDownColor {
            get { return (Color)GetValue(PressedDownProperty); }
            set { SetValue(PressedDownProperty, value); }
        }
    }
