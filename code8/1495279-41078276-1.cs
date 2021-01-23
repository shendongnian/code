    using System.Windows.Controls;
    
    namespace YourNamespace
    {
        public partial class StudentControl : UserControl
        {
            public StudentControl(string labelText)
            {
                InitializeComponent();
    
                StudentLabel.Content = labelText;
            }
        }
    }
