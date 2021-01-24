    System.Windows.Controls.TextBox dynamicTextBox = new System.Windows.Controls.TextBox();
    string previousvalue;
        public MainWindows()
        {
            InitializeComponent();
            //subscribe to previewKeyDown, KeyDown will not work for enter key
            dynamicTextBox.PreviewKeyDown += dynamicTextBox_KeyDown;
        }
        // this will hit if any key is pressed
        void dynamicTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                 using (DatabaseConnector databaseConnection = new DatabaseConnector(ApplicationConstants.ConnectionString))
                 using (ProjectsTable projectsTable = new ProjectsTable(databaseConnection))
                {
                //Here Filter the Name from project Table which DbActive state is zero
                projectsTable.AddFilter(new Filter<ProjectsColumnTypes>(ProjectsColumnTypes.DbActive, CompareOperator.Equals, true));
                projectsTable.Read();
                projectsTable.AddFilter(new Filter<ProjectsColumnTypes>(ProjectsColumnTypes.Name, CompareOperator.Equals, dynamicTextBox.Text));
                projectsTable.Read();
                foreach (DtoProjectsRow row in projectsTable.Rows)
                {
                    //Guid DbId = row.DbId;
                    Guid DbId = row.DbId;
                    var UpdateRow = projectsTable.NewRow();
                    UpdateRow.Name = dynamicTextBox.Text;
                    UpdateRow.DbId = DbId;
                    UpdateRow.DbActive = true;
                    // Alter the row to the table.
                    projectsTable.AlterRow(UpdateRow);
                    // Write the new row to the database.
                    projectsTable.Post();
                    //Add the items in comboBox
                    lstbxindex.Items.Add(dynamicTextBox.Text);
                }
                // dynamicTextBox = e.Source as System.Windows.Controls.TextBox;
            }
        }
    private void items_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        //Get the index value
        var index = lstbxindex.Items.IndexOf(lstbxindex.SelectedItem);
        //set the textbox height and width property 
        dynamicTextBox.Width = 230;
        dynamicTextBox.Height = 50;
        //Add a textbox to the listbox 
        this.lstbxindex.Items.Add(dynamicTextBox);
        //To assign the selectedITem values to textbox
        dynamicTextBox.Text = lstbxindex.SelectedItem.ToString();
        //Get the textbox values before editing
        previousvalue = dynamicTextBox.Text;
        //Remove the values from the listbox item
        lstbxindex.Items.RemoveAt(index);
        dynamicTextBox.AcceptsReturn = true;
    }
