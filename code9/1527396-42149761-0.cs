       public MainWindow()
        {
            InitializeComponent();
           
            DataTable dt = new DataTable();
            dt.Columns.Add("Col", typeof(string));
            DataRow dr1 = dt.NewRow();
            dr1[0] =  "row1" ;
            DataRow dr2 = dt.NewRow();
            dr2[0] = "row2";
            DataRow dr3 = dt.NewRow();
            dr3[0] = "row3";
            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);
            dt.Rows.Add(dr3);
            dataGrid.ItemsSource = dt.AsDataView();
            
            dataGrid.ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
        }
        private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            // This will ensure, items are generated over UI.
            if (dataGrid.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
            {
                int index = 1; // add logic to get index of row to be styled.
                var row = (DataGridRow)dataGrid.ItemContainerGenerator
                                                     .ContainerFromIndex(index);
                
                // creating style, can be picked from resources aswell.
                Style style = new Style
                {
                    TargetType = typeof(Control)
                };
                style.Setters.Add(new Setter(Control.BackgroundProperty, Brushes.Green));
                // Applied logic
                row.Style = style;
            }
        }
