    namespace WpfApplication3
    {
        // View with no code-behind
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    
        // From plain to encripted Text
        public class EncryptConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter,
                    System.Globalization.CultureInfo culture)
            {
                string plainText = (string)value;
                char[] chars = new char[plainText.Length];
                string key = "=2/3E*45-`~6<>!,.7+8[]9|:0";
    
                for (int i = 0; i < plainText.Length; i++)
                {
                    if (plainText[i] == ' ')
                    {
                        chars[i] = ' ';
                    }
                    else
                    {
                        int j = plainText[i] - 97;
                        chars[i] = key[j];
                    }
                }
                return new string(chars);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter,
                    System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    
        // From encripted to plain Text
        public class DecryptConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter,
                    System.Globalization.CultureInfo culture)
            {
                string cipherText = (string)value;
                char[] chars = new char[cipherText.Length];
                string key = "=2/3E*45-`~6<>!,.7+8[]9|:0";
    
                for (int i = 0; i < cipherText.Length; i++)
                {
                    if (cipherText[i] == ' ')
                    {
                        chars[i] = ' ';
                    }
                    else
                    {
                        int j = key.IndexOf(cipherText[i]) + 97;
                        chars[i] = (char)j;
                    }
                }
    
                return new string(chars);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter,
                    System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
