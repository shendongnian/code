    <DataGridTextColumn Binding="{Binding Path=., Converter={StaticResource GooglePositionConvertor}}">
        <DataGridTextColumn.CellStyle>
            <Style TargetType="{x:Type DataGridCell}">
                <Setter Property="Foreground" Value="{Binding Path=Content, RelativeSource={RelativeSource Self}, 
                    Converter={StaticResource ChangeBrushColour}}"/>
            </Style>
        </DataGridTextColumn.CellStyle>
    </DataGridTextColumn>
----------
    public class Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TextBlock content = value as TextBlock;
            if(content != null)
            {
                string text = content.Text;
                if(string.IsNullOrEmpty(text))
                {
                    DependencyPropertyDescriptor dpd = DependencyPropertyDescriptor.FromProperty(TextBlock.TextProperty, typeof(TextBlock));
                    if (dpd != null)
                        dpd.AddValueChanged(content, OnTextChanged);
                }
                else
                {
                    OnTextChanged(content, EventArgs.Empty);
                }
            }
            return Binding.DoNothing;
        }
        private void OnTextChanged(object sender, EventArgs e)
        {
            TextBlock textBlock = sender as TextBlock;
            string converterText = textBlock.Text;
            //set foreground based on text...
            textBlock.Foreground = Brushes.Violet;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
