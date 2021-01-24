        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Input;
        
        namespace DataGridInUserControlDemo.UserControls
        {
            public partial class DGPlusUC : UserControl
            {
                public DGPlusUC()
                {
                    InitializeComponent();
                }
        
                public const string BannerTextPropertyName = "BannerText";
        
                public string BannerText
                {
                    get
                    {
                        return (string)GetValue(BannerTextProperty);
                    }
                    set
                    {
                        SetValue(BannerTextProperty, value);
                    }
                }
        
                public static readonly DependencyProperty BannerTextProperty = DependencyProperty.Register(
                    BannerTextPropertyName,
                    typeof(string),
                    typeof(DGPlusUC));
        
                public const string ButtonContentPropertyName = "ButtonContent";
        
                public string ButtonContent
                {
                    get
                    {
                        return (string)GetValue(ButtonContentProperty);
                    }
                    set
                    {
                        SetValue(ButtonContentProperty, value);
                    }
                }
        
                public static readonly DependencyProperty ButtonContentProperty = DependencyProperty.Register(
                    ButtonContentPropertyName,
                    typeof(string),
                    typeof(DGPlusUC));
        
                public const string ButtonCommandPropertyName = "ButtonCommand";
        
                public ICommand ButtonCommand
                {
                    get
                    {
                        return (ICommand)GetValue(ButtonCommandProperty);
                    }
                    set
                    {
                        SetValue(ButtonCommandProperty, value);
                    }
                }
        
                public static readonly DependencyProperty ButtonCommandProperty = DependencyProperty.Register(
                    ButtonCommandPropertyName,
                    typeof(ICommand),
                    typeof(DGPlusUC));
        
                public const string InnerContentPropertyName = "InnerContent";
        
                public UIElement InnerContent
                {
                    get
                    {
                        return (UIElement)GetValue(InnerContentProperty);
                    }
                    set
                    {
                        SetValue(InnerContentProperty, value);
                    }
                }
        
                public static readonly DependencyProperty InnerContentProperty = DependencyProperty.Register(
                    InnerContentPropertyName,
                    typeof(UIElement),
                    typeof(DGPlusUC));
            }
        }
