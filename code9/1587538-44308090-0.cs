    public class DataGridSyntaxColumn : DataGridTextColumn
    {
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            SyntaxTextBlock textBlock = new SyntaxTextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                SyntaxType = VARIANT
            };
            BindingBase binding = Binding;
            if (binding != null)
                BindingOperations.SetBinding(textBlock, TextBlock.TextProperty, binding);
            else
                BindingOperations.ClearBinding(textBlock, TextBlock.TextProperty);
            return textBlock;
        }
    }
----------
    <local:DataGridSyntaxColumn MinWidth="100" Binding="{Binding Variants[0].Name}"  Width="250" />
