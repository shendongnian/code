    <Path Grid.Row="0" Grid.Column="0" Grid.RowSpan="2" 
          MaxHeight="45" MaxWidth="45" Stretch="Uniform" 
          Fill="{Binding DocumentType, Converter={StaticResource DocumentTypeColor}}"
          Data="{StaticResource Ico}"/>
<!---->
    public class DocumentTypeToColorConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var iDocumentType = Int32.Parse( (string) value);
                switch (iDocumentType)
                {
                    case 1:
                    case 2:
                        return Brushes.Blue;
                    case 3:
                        return Brushes.Red;
                    default:
                        return Brushes.Black;
                }
            }
            return Brushes.Black;
        }
    }
