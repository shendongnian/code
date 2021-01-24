    public class SystemConfigComboBox
    {
        public SystemConfigComboBox()
        {
            ComboBoxValues = new ObservableCollection<ComboBoxValue>();
        }
        public static readonly DependencyProperty ComboBoxValuesProperty =
                DependencyProperty.Register("ComboBoxValues", typeof(ObservableCollection<ComboBoxValue>), typeof(SystemConfigComboBox)));
        ...
    }
