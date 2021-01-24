            var table = new DataTable {TableName = "AddressData"};
            // Declare DataColumn and DataRow variables.
            // Create new DataColumns, set DataType, ColumnName and add to DataTable.    
            // Create Addressee column.
            var column = new DataColumn { DataType = Type.GetType("System.String"), ColumnName = "Addressee" };
            table.Columns.Add(column);
            // Create Address1 column.
            column = new DataColumn { DataType = Type.GetType("System.String"), ColumnName = "Address1" };
            table.Columns.Add(column);
            // Create Address2 column.
            column = new DataColumn { DataType = Type.GetType("System.String"), ColumnName = "Address2" };
            table.Columns.Add(column);
            // Create CityOrTown column.
            column = new DataColumn { DataType = Type.GetType("System.String"), ColumnName = "CityOrTown" };
            table.Columns.Add(column);
            // Create Country column.
            column = new DataColumn { DataType = Type.GetType("System.String"), ColumnName = "Country" };
            table.Columns.Add(column);
            // Create CountryId column.
            column = new DataColumn { DataType = Type.GetType("System.Int64"), ColumnName = "CountryId" };
            table.Columns.Add(column);
            // Create CountyOrState column.
            column = new DataColumn { DataType = Type.GetType("System.String"), ColumnName = "CountyOrState" };
            table.Columns.Add(column);
            // Create Postcode column.
            column = new DataColumn { DataType = Type.GetType("System.String"), ColumnName = "Postcode" };
            table.Columns.Add(column);
            // Create Formatted Address column.
            column = new DataColumn { DataType = Type.GetType("System.String"), ColumnName = "FormattedAddress" };
            table.Columns.Add(column);
