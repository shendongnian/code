        public class HeaderToImageConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
                if (!designMode)
                {
                    if ((value as string).Contains(@"."))
                    {
                        Uri uri = new Uri("pack://application:,,,/images/File.png");
                        BitmapImage source = new BitmapImage(uri);
                        return source;
                    }
                    else
                    {
                        if (!(value as string).Contains(@":"))
                        {
                            Uri uri = new Uri("pack://application:,,,/images/folder.png");
                            BitmapImage source = new BitmapImage(uri);
                            return source;
                        }
                        else
                        {
                            Uri uri = new Uri("pack://application:,,,/images/diskdrive.png");
                            BitmapImage source = new BitmapImage(uri);
                            return source;
                        }
                    }
                }
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotSupportedException("Cannot convert back");
            }
        }
