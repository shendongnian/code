    public class MyComboBox : ComboBox
    {
        static MyComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyComboBox),
                new System.Windows.FrameworkPropertyMetadata(typeof(MyComboBox)));
        }
        public MyComboBox()
        {
        }
    }
