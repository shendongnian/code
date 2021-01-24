    using System.Collections.Generic;
    using System.Windows;
    
    namespace PassingValuesFromFormToForm_45425412
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
            }
    
            public Window1(dgvEntry incomingItem)
            {
                InitializeComponent();
                dataGrid.AutoGenerateColumns = true;
                dataGrid.ItemsSource = new List<dgvEntry> { incomingItem };
            }
        }
    }
