    public static readonly BindableProperty ArraySourceProperty =
    	BindableProperty.Create(nameof(ArraySource), typeof(byte[]), typeof(MVVMImage), null,
    	BindingMode.OneWay, null, OnArraySourcePropertyChanged);
    
    public byte[] ArraySource
    {
    	get { return (byte[])GetValue(ArraySourceProperty); }
    	set { SetValue(ArraySourceProperty, value); }
    }
    
    private static void OnArraySourcePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
    	var control = (MVVMImage) bindable;
    	if (control != null)
    	{
    		control.Source = ImageSource.FromStream(() => new  MemoryStream(newvalue));
    	}
    }
