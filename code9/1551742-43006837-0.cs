    public class ActiveConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Length > 1 && values[0] is bool && values[1] is CheckBox)
            {
                var chk = (CheckBox) values[1];
                chk.IsChecked = (bool) values[0];
            }
            return DependencyProperty.UnsetValue;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
<!---->
    <StackPanel Grid.Row="1">
        <CheckBox Name="zoom" />
        
        <ItemsControl >
            <ItemsControl.Resources>
                <Style TargetType="TextBox">
                    <Setter Property="Tag">
                        <Setter.Value>
                            <MultiBinding>
                                <MultiBinding.Converter>
                                    <wpfDemos:ActiveConverter/>
                                </MultiBinding.Converter>
                                <Binding Path="IsMouseOver" RelativeSource="{RelativeSource Self}"/>
                                <Binding ElementName="zoom"/>
                            </MultiBinding>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ItemsControl.Resources>
                    
            <TextBox/>
            <TextBox/>
            <TextBox />
        </ItemsControl>        
    </StackPanel>
