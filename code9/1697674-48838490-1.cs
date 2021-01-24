          public class MultilineTextBoxEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
            {
                public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem)
                {
                    System.Windows.Controls.TextBox textBox = new 
     System.Windows.Controls.TextBox();
                    textBox.AcceptsReturn = true;
                    //create the binding from the bound property item to the editor
                    var _binding = new Binding("Value"); //bind to the Value property of the PropertyItem
                    _binding.Source = propertyItem;
                    _binding.ValidatesOnExceptions = true;
                    _binding.ValidatesOnDataErrors = true;
                    _binding.Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;
                    BindingOperations.SetBinding(textBox, System.Windows.Controls.TextBox.TextProperty, _binding);
                    return textBox;
                }
            }
