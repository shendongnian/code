       <Window.Resources>
            <local:DictValueConverter x:Key="dictValCnv"/>        
        </Window.Resources>
    <TextBlock.Text>
    	<MultiBinding Converter="{StaticResource dictValCnv}">
    		<Binding Path="MyDictionary"/>
    		<Binding RelativeSource="{RelativeSource Self}" Path="Name"/>
    	</MultiBinding>
    </TextBlock.Text>
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Data;
    public class DictValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values==null || values.Length<2 )
            {
                return false;
            }
            
            var dict = values[0] as IDictionary;
            if(dict.Contains(values[1]))
		{
			return dict[values[1]];
		}
            return "KeyNotFound";
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
