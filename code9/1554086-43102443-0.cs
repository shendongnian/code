    public class SampleRowValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            BindingGroup bg = value as BindingGroup;
            if (bg != null && bg.Items.Count > 0)
            {
                DataGridRow dgrow = bg.Owner as DataGridRow;
                if(dgrow != null)
                {
                    DataGrid dg = GetParent<DataGrid>(dgrow);
                    // ... add more
                }
            }
            return new ValidationResult(true, null);
        }
        private T GetParent<T>(DependencyObject d) where T : class
        {
            while (d != null && !(d is T))
            {
                d = VisualTreeHelper.GetParent(d);
            }
            return d as T;
        }
    }
