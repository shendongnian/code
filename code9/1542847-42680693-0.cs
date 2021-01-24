    public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(ContentPage), null, propertyChanged: TemplateUtilities.OnContentChanged);
    public View Content
	{
		get { return (View)GetValue(ContentProperty); }
		set { SetValue(ContentProperty, value); }
	}
