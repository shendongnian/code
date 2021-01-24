	public static readonly BindableProperty MyCommandProperty = BindableProperty.Create(nameof(MyCommand), typeof(Command), typeof(MyObjectType), null, BindingMode.OneWay);
	public Command MyCommand
	{
		get { return (Command)GetValue(MyCommandProperty); }
		set { SetValue(MyCommandProperty, value); }
	} 
