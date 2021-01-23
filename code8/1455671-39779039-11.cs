    public partial class DataGridBetterCheckBoxColumn : DataGridTemplateColumn
    {
        public BindingBase isChecked { get; set; }
     
        public DataGridBetterCheckBoxColumn()
        {
            InitializeComponent();
        }
              
        void CheckBox_Loaded(object sender, RoutedEventArgs e)
        {          
            CheckBox cb = sender as CheckBox;
            BindingOperations.SetBinding(cb , CheckBox.IsCheckedProperty, isChecked);
        }
    } 
