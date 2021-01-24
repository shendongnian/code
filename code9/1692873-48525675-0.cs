    public static class Logic
    {
        public enum Equation { Empty, AandBorCandD, ... }; // more options
        public static bool GetA(DependencyObject obj) => (bool)obj.GetValue(AProperty);
        public static void SetA(DependencyObject obj, bool value) => obj.SetValue(AProperty, value);
        public static readonly DependencyProperty AProperty =
            DependencyProperty.RegisterAttached("A", typeof(bool), typeof(Logic), new PropertyMetadata(OnValueChanged));
        // reduced content, normal attached properties, defined similar to AProperty above
        public static bool GetB... // BProperty
        public static bool GetC... // CProperty
        public static bool GetD... // DProperty
        public static Equation GetEquation... // EquationProperty
        public static bool GetR... // RProperty = result
        static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            switch (GetEquation(obj))
            {
                case Equation.AandBorCandD:
                    SetR(obj, GetA(obj) && GetB(obj) || GetC(obj) && GetD(obj));
                    break;
                ... // other options
            }
        }
