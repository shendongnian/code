    public class NameValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var attrName = (XmlAttribute)values[0];
            var attrValue = (XmlAttribute)values[1];
            //  Do stuff here. 
            return attrName.Value + " -> " + attrValue.Value;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    <Window.Resources>
        <local:NameValueConverter x:Key="NameValueConverter" />
    </Window.Resources>
...
    <Expander 
        ExpandDirection="Down" 
        Width="Auto" 
        Padding="4"
        IsExpanded="{Binding XPath=@Expand}"
        >
        <Expander.Style>
            <Style TargetType="Expander">
                <Setter Property="FontWeight" Value="Bold" />
                <Style.Triggers>
                    <!-- 
                    You can do a regular Trigger instead of a DataTrigger and not
                    have to bother with RelativeSource=Self
                    -->
                    <Trigger 
                        Property="IsExpanded"
                        Value="True">
                        <!-- stuff -->
                    </Trigger>
                </Style.Triggers>
            </Style>
        </Expander.Style>
        <Expander.Header>
            <MultiBinding Converter="{StaticResource NameValueConverter}">
                <Binding XPath="@Name" />
                <Binding XPath="@Value" />
            </MultiBinding>
        </Expander.Header>
    </Expander>
