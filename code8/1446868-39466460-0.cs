        public static readonly DependencyProperty SelectedFormulasProperty =
            DependencyProperty.Register("SelectedFormulas", typeof(SelectedFormulaCollection), typeof(CustomNumericField));
        public SelectedFormulaCollection SelectedFormulas
        {
            get { return GetValue(SelectedFormulasProperty) as SelectedFormulaCollection; }
            set { SetValue(SelectedFormulasProperty, value); }
        }
