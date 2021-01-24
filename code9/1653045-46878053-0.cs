    public class ValidationChecker : Freezable
    {
        public static List<DependencyObject> elements = new List<DependencyObject>();
        public static int GetValidationObject(DependencyObject obj)
        {
            return (int)obj.GetValue(ValidationObjectProperty);
        }
        public static void SetValidationObject(DependencyObject obj, int value)
        {
            obj.SetValue(ValidationObjectProperty, value);
        }
        // Using a DependencyProperty as the backing store for ErrorCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValidationObjectProperty =
            DependencyProperty.RegisterAttached("ValidationObject", typeof(DependencyObject), typeof(ValidationChecker), new PropertyMetadata(null, OnValueChanged));
        public static bool IsValid()
        {
            foreach (var item in elements)
            {
                if (Validation.GetHasError(item)) return false;
            }
            return true;
        }
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            elements.Add(d);
        }
        protected override Freezable CreateInstanceCore()
        {
            return new ValidationChecker();
        }
    }
