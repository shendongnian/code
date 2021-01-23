    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Collections.Generic;
    using System.Windows.Markup.Primitives;
    
    namespace TemplateCode
    {
        public partial class Template : UserControl
        {
            public Template()
            {
                InitializeComponent();
            }
    
            public static readonly DependencyProperty ButtonProperty =
                DependencyProperty.Register("Button", typeof(Button), typeof(Template),
                    new UIPropertyMetadata(new PropertyChangedCallback(ButtonChangedCallback)));
    
            public Button MyButton
            {
                get { return (Button)GetValue(ButtonProperty); }
                set { SetValue(ButtonProperty, value); }
            }
    
            public static List<DependencyProperty> GetDependencyProperties(Object element)
            {
                List<DependencyProperty> properties = new List<DependencyProperty>();
                MarkupObject markupObject = MarkupWriter.GetMarkupObjectFor(element);
                if (markupObject != null)
                {
                    foreach (MarkupProperty mp in markupObject.Properties)
                    {
                        if (mp.DependencyProperty != null)
                        {
                            properties.Add(mp.DependencyProperty);
                        }
                    }
                }
                return properties;
            }
    
            private static void ButtonChangedCallback(object sender, DependencyPropertyChangedEventArgs args)
            {
                // Get button defined by user in MainWindow
                Button userButton     = (Button)args.NewValue;
                // Get template button in UserControl
                UserControl template  = (UserControl)sender;
                Button templateButton = (Button)template.FindName("button");
                // Get userButton props and change templateButton accordingly
                List<DependencyProperty> properties = GetDependencyProperties(userButton);
                foreach(DependencyProperty property in properties)
                {
                    if (templateButton.GetValue(property) != userButton.GetValue(property))
                    {
                        templateButton.SetValue(property, userButton.GetValue(property));
                    }
                }
            }
        }
    }
