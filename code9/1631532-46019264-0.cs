	public class RippleButton : Button
	{
		public static readonly BindableProperty ClickedBackgroundColorProperty =
            BindableProperty.Create(
                "ClickedBackgroundColor", typeof(Color), typeof(RippleButton),
                defaultValue: Color.FromRgb(76, 175, 80));
        public Color ClickedBackgroundColor
        {
            get { return (Color)GetValue(ClickedBackgroundColorProperty); }
            set { SetValue(ClickedBackgroundColorProperty, value); }
        }
        public static readonly BindableProperty AsyncCommandProperty =
            BindableProperty.Create(
                "AsyncCommand", typeof(IAsyncCommand), typeof(RippleButton),
                defaultValue: default(IAsyncCommand));
        public IAsyncCommand AsyncCommand
        {
            get { return (IAsyncCommand)GetValue(AsyncCommandProperty); }
            set { SetValue(AsyncCommandProperty, value); }
        }
        public RippleButton()
		{
			const int animationTime = 150;
			TextColor = Color.FromRgb(255, 255, 255);
			BackgroundColor = Color.FromRgb(255, 87, 34);
			Clicked += async (sender, e) =>
			{
                //execute command only if button is enabled.
                if (!IsEnabled)
                    return;
                //continue only if command is executable, and not allow multiple click(s)
                if (AsyncCommand == null || !AsyncCommand.CanExecute(CommandParameter))
                    return;
                var defaultColor = BackgroundColor;
                BackgroundColor = ClickedBackgroundColor;
                IsEnabled = false;
                await AsyncCommand.ExecuteAsync(CommandParameter);
				await this.ScaleTo(1.2, animationTime);
				await this.ScaleTo(1, animationTime);
                IsEnabled = true;
                BackgroundColor = defaultColor;
			};
		}
    }
