        private void Prepare()
        {
            // Set up the grid
            AutoGenerateColumns = false;
            Columns.Clear();
            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            var column = new DataGridViewTextBoxColumn
                             {
                                 AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                                 DataPropertyName = "Addressee",
                                 DefaultCellStyle = CellStyles.Text,
                                 HeaderText = @"Addressee",
                                 Name = "AddresseeColumn",
                             };
            Columns.Add(column);
            // more columns added here to suit
            // Add invisible Id column
            var idColumn = new DataGridViewTextBoxColumn
                               {
                                   DataPropertyName = "CountryId",
                                   Name = "CountryIdColumn",
                                   HeaderText = @"Id",
                                   Width = 0,
                                   Visible = false
                               };
            Columns.Add(idColumn);
        }
