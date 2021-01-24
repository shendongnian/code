    public class FinancialTextColumn : DataGridTextColumn
    {
        private static readonly FinancialConverter _converter = new FinancialConverter();
        public override BindingBase Binding
        {
            get { return base.Binding; }
            set
            {
                base.Binding = value;
                //generate the cell template:
                Binding binding = base.Binding as Binding;
                if (binding != null && binding.Path != null && !string.IsNullOrEmpty(binding.Path.Path))
                    CellStyle = CreateCellStyle(binding.Path.Path);
            }
        }
        private static Style CreateCellStyle(string sourceProperty)
        {
            Style style = new Style(typeof(DataGridCell));
            style.Setters.Add(new Setter(Control.ForegroundProperty, new Binding(sourceProperty) { Converter = _converter }));
            return style;
        }
    }
