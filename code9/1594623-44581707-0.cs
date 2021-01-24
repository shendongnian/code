        <ContentPage.Resources>
        <ResourceDictionary >
            <local:ChatTextAlignmentConverter x:Key="ChatTextAlignmentConverter">
            </local:ChatTextAlignmentConverter>
        </ResourceDictionary>
    </ContentPage.Resources>
    <Frame  Margin="10,0,10,0" Padding="10,5,10,5"  HorizontalOptions="{Binding TextAlign, Converter={StaticResource ChatTextAlignmentConverter}}" BackgroundColor="{Binding BackgroundColor}"/>
     public class ChatTextAlignmentConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string valueAsString = value.ToString();
                switch (valueAsString)
                {
                    case ("EndAndExpand"):
                        {
                            return LayoutOptions.EndAndExpand;
                        }
                    case ("StartAndExpand"):
                        {
                            return LayoutOptions.StartAndExpand;
                        }
                    default:
                        {
                            return LayoutOptions.StartAndExpand;
                        }
                }
            }
            else
            {
                return LayoutOptions.StartAndExpand;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    
