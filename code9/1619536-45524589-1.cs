    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    namespace ButtonRendererDemo
    {
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class ValueConverterPage : ContentPage
        {
            public ValueConverterPage()
            {
                InitializeComponent();
                BindingContext = this;
            }
    
            bool? alarmStatus = null;
            public bool? AlarmStatus
            {
                get
                {
                    return alarmStatus;
                }
                set
                {
                    alarmStatus = value;
                    OnPropertyChanged("AlarmStatus");
                }
            }
    
            private void Button_Clicked(object sender, EventArgs e)
            {
                switch (AlarmStatus)
                {
                    case true:
                        AlarmStatus = false;
                        break;
                    case false:
                        AlarmStatus = null;
                        break;
                    case null:
                        AlarmStatus = true;
                        break;
                }
            }
        }
    
        public class ColorConverter : IValueConverter
        {
     
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                switch (value as bool?)
                {
                    case true:
                        return Color.Green;
                    case false:
                        return Color.Red;
                    case null:
                    default:
                        return Color.Black;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
        }
    }
