    try
            {
                OleDbConnection conn = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0; " +
                    "Data Source=MaterialDB.mdb");
                //conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM myTable", conn);
                myDataSet = new DataSet();
                adapter.Fill(myDataSet, "myTable");
                DataTable myDataTable = myDataSet.Tables["myTable"];
                // Create the UpdateCommand.
                OleDbCommand command = new OleDbCommand(
                    "UPDATE myTable SET Type = @Type, Description = @Description " +
                    "WHERE ID = @ID", conn);
                // Add the parameters for the UpdateCommand.
                command.Parameters.Add("@Type", OleDbType.Char, 255, "Type");
                command.Parameters.Add("@Description", OleDbType.Char, 255, "Description");
                command.Parameters.Add("@ID", OleDbType.Integer, 5, "ID");
                adapter.UpdateCommand = command;
                // Update the DB whenever a row changes
                myDataTable.RowChanged += (s, f) =>
                {
                    adapter.Update(myDataTable);
                };
                var be = CatalogsGrid.GetBindingExpression(DataGrid.ItemsSourceProperty);
                CatalogsGrid.DataContext = myDataSet;
                CatalogsGrid.ItemsSource = myDataSet.Tables[0].DefaultView;
                Binding nbe = new Binding();
                nbe.Source = myDataSet;
                nbe.Mode = BindingMode.TwoWay;
                nbe.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                nbe.Path = new PropertyPath("myTable");
                nbe.BindsDirectlyToSource = true;
                CatalogsGrid.SetBinding(DataGrid.ItemsSourceProperty, nbe);
                
                CatalogsGrid.Items.Refresh();
            }
