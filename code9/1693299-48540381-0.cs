    <Window x:Class="..."
    ...
            x:Name="_this" 
    		...
    		>
    <Window.Resources>
    	<local:DepPropConverter x:Key="Convert" MyList="{Binding DataContext.YourListInViewmodel, Source={x:Reference _this}}"/>
    </Window.Resources>
    
    <CheckBox IsChecked="{Binding item, Converter={StaticResource Convert}}"></CheckBox>
	
    public class DepPropConverter : FrameworkElement, IValueConverter
    	{
    
    		public static readonly DependencyProperty MyListProperty =
    			DependencyProperty.Register("MyList", typeof(IList), typeof(DepPropConverter), new PropertyMetadata(null));
    
    		public IList MyList
    		{
    			get { return (IList)GetValue(MyListProperty); }
    			set { SetValue(MyListProperty, value); }
    		}
    
    		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    		{
    			return value;
    		}
    
    		public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
    		{
    			return value;
    		}
    	}
