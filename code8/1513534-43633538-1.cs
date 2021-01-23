	using Microsoft.Win32;
    using System.Windows;
    using System.Windows.Data;
    using Xceed.Wpf.Toolkit.PropertyGrid;
    using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
    
    namespace MyControls
    {
        /// <summary>
        /// Interaction logic for PropertyGridFilePicker.xaml
        /// </summary>
        public partial class PropertyGridFilePicker : ITypeEditor
        {
            public PropertyGridFilePicker()
            {
                InitializeComponent();
            }
    
            public string Value
            {
                get { return (string)GetValue(ValueProperty); }
                set { SetValue(ValueProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register("Value", typeof(string), typeof(PropertyGridFilePicker), new PropertyMetadata(null));
    
    
    
            public FrameworkElement ResolveEditor(PropertyItem propertyItem)
            {
                Binding binding = new Binding("Value");
                binding.Source = propertyItem;
                binding.Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;
                BindingOperations.SetBinding(this, ValueProperty, binding);
                return this;
            }
    
            private void PickFileButton_Click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog fd = new OpenFileDialog();
                if (fd.ShowDialog() == true && fd.CheckFileExists)
                {
                    Value = fd.FileName;
                }
            }
        }
    }
