     public interface IDataPageRetriever
        {
            DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage);
        }
        public class DataRetriever : IDataPageRetriever
        {
            private string tableName;
            private SqlCommand command;
    
            public DataRetriever(string connectionString, string tableName,string sortby,bool desc)
            {
                if (sortby != null)
                    columnToSortBy = sortby;
                sortdesc = desc;
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                command = connection.CreateCommand();
                this.tableName = tableName;
            }
    
            private int rowCountValue = -1;
    
            public int RowCount
            {
                get
                {
                    // Return the existing value if it has already been determined.
                    if (rowCountValue != -1)
                    {
                        return rowCountValue;
                    }
    
                    // Retrieve the row count from the database.
                    command.CommandText = "SELECT COUNT(*) FROM " + tableName;
                    rowCountValue = (int)command.ExecuteScalar();
                    return rowCountValue;
                }
            }
    
            private DataColumnCollection columnsValue;
    
            public DataColumnCollection Columns
            {
                get
                {
                    // Return the existing value if it has already been determined.
                    if (columnsValue != null)
                    {
                        return columnsValue;
                    }
    
                    // Retrieve the column information from the database.
                    command.CommandText = "SELECT * FROM " + tableName;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    adapter.FillSchema(table, SchemaType.Source);
                    columnsValue = table.Columns;
                    return columnsValue;
                }
            }
    
            private string commaSeparatedListOfColumnNamesValue = null;
    
            private string CommaSeparatedListOfColumnNames
            {
                get
                {
                    // Return the existing value if it has already been determined.
                    if (commaSeparatedListOfColumnNamesValue != null)
                    {
                        return commaSeparatedListOfColumnNamesValue;
                    }
    
                    // Store a list of column names for use in the
                    // SupplyPageOfData method.
                    System.Text.StringBuilder commaSeparatedColumnNames =
                        new System.Text.StringBuilder();
                    bool firstColumn = true;
                    foreach (DataColumn column in Columns)
                    {
                        if (!firstColumn)
                        {
                            commaSeparatedColumnNames.Append(", ");
                        }
                        commaSeparatedColumnNames.Append("[" + column.ColumnName + "]");
                        firstColumn = false;
                    }
    
                    commaSeparatedListOfColumnNamesValue =
                        commaSeparatedColumnNames.ToString();
                    return commaSeparatedListOfColumnNamesValue;
                }
            }
    
            // Declare variables to be reused by the SupplyPageOfData method.
            private string columnToSortBy;
            private bool sortdesc = false;
            private SqlDataAdapter adapter = new SqlDataAdapter();
    
            public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
            {
                // Store the name of the ID column. This column must contain unique 
                // values so the SQL below will work properly.
                if (columnToSortBy == null)
                {
                    columnToSortBy = this.Columns[0].ColumnName;
                }
    
                if (!this.Columns[columnToSortBy].Unique)
                {
                    throw new InvalidOperationException(String.Format(
                        "Column {0} must contain unique values.", columnToSortBy));
                }
    
                // Retrieve the specified number of rows from the database, starting
                // with the row specified by the lowerPageBoundary parameter.
    
                //DataTable Results = Global.db.Customers.Select<>
                if (sortdesc == false)
                    command.CommandText = "Select Top " + rowsPerPage + " " +
                        CommaSeparatedListOfColumnNames + " From " + tableName +
                        " WHERE " + columnToSortBy + " NOT IN (SELECT TOP " +
                        lowerPageBoundary + " " + columnToSortBy + " From " +
                        tableName + " Order By " + columnToSortBy +
                        ") Order By " + columnToSortBy;
    
                else
                {
                    command.CommandText = "Select Top " + rowsPerPage + " " +
                        CommaSeparatedListOfColumnNames + " From " + tableName +
                        " WHERE " + columnToSortBy + " NOT IN (SELECT TOP " +
                        lowerPageBoundary + " " + columnToSortBy + " From " +
                        tableName + " Order By " + columnToSortBy + " DESC" +
                        ") Order By " + columnToSortBy + " DESC";
                }
                adapter.SelectCommand = command;
    
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.Fill(table);
                return table;
            }
    
        }
        public class Cache
        {
            private static int RowsPerPage;
    
            // Represents one page of data.  
            public struct DataPage
            {
                public DataTable table;
                private int lowestIndexValue;
                private int highestIndexValue;
    
                public DataPage(DataTable table, int rowIndex)
                {
                    this.table = table;
                    lowestIndexValue = MapToLowerBoundary(rowIndex);
                    highestIndexValue = MapToUpperBoundary(rowIndex);
                    System.Diagnostics.Debug.Assert(lowestIndexValue >= 0);
                    System.Diagnostics.Debug.Assert(highestIndexValue >= 0);
                }
    
                public int LowestIndex
                {
                    get
                    {
                        return lowestIndexValue;
                    }
                }
    
                public int HighestIndex
                {
                    get
                    {
                        return highestIndexValue;
                    }
                }
    
                public static int MapToLowerBoundary(int rowIndex)
                {
                    // Return the lowest index of a page containing the given index.
                    return (rowIndex / RowsPerPage) * RowsPerPage;
                }
    
                private static int MapToUpperBoundary(int rowIndex)
                {
                    // Return the highest index of a page containing the given index.
                    return MapToLowerBoundary(rowIndex) + RowsPerPage - 1;
                }
            }
    
            private DataPage[] cachePages;
            private IDataPageRetriever dataSupply;
    
            public Cache(IDataPageRetriever dataSupplier, int rowsPerPage)
            {
                dataSupply = dataSupplier;
                Cache.RowsPerPage = rowsPerPage;
                LoadFirstTwoPages();
            }
    
            // Sets the value of the element parameter if the value is in the cache.
            private bool IfPageCached_ThenSetElement(int rowIndex,
                int columnIndex, ref string element)
            {
                if (IsRowCachedInPage(0, rowIndex))
                {
                    element = cachePages[0].table
                        .Rows[rowIndex % RowsPerPage][columnIndex].ToString();
                    return true;
                }
                else if (IsRowCachedInPage(1, rowIndex))
                {
                    element = cachePages[1].table
                        .Rows[rowIndex % RowsPerPage][columnIndex].ToString();
                    return true;
                }
    
                return false;
            }
    
            public string RetrieveElement(int rowIndex, int columnIndex)
            {
                string element = null;
    
                if (IfPageCached_ThenSetElement(rowIndex, columnIndex, ref element))
                {
                    return element;
                }
                else
                {
                    return RetrieveData_CacheIt_ThenReturnElement(
                        rowIndex, columnIndex);
                }
            }
    
            private void LoadFirstTwoPages()
            {
                cachePages = new DataPage[]{
                new DataPage(dataSupply.SupplyPageOfData(
                    DataPage.MapToLowerBoundary(0), RowsPerPage), 0),
                new DataPage(dataSupply.SupplyPageOfData(
                    DataPage.MapToLowerBoundary(RowsPerPage),
                    RowsPerPage), RowsPerPage)};
            }
    
            private string RetrieveData_CacheIt_ThenReturnElement(
                int rowIndex, int columnIndex)
            {
                // Retrieve a page worth of data containing the requested value.
                DataTable table = dataSupply.SupplyPageOfData(
                    DataPage.MapToLowerBoundary(rowIndex), RowsPerPage);
    
                // Replace the cached page furthest from the requested cell
                // with a new page containing the newly retrieved data.
                cachePages[GetIndexToUnusedPage(rowIndex)] = new DataPage(table, rowIndex);
    
                return RetrieveElement(rowIndex, columnIndex);
            }
    
            // Returns the index of the cached page most distant from the given index
            // and therefore least likely to be reused.
            private int GetIndexToUnusedPage(int rowIndex)
            {
                if (rowIndex > cachePages[0].HighestIndex &&
                    rowIndex > cachePages[1].HighestIndex)
                {
                    int offsetFromPage0 = rowIndex - cachePages[0].HighestIndex;
                    int offsetFromPage1 = rowIndex - cachePages[1].HighestIndex;
                    if (offsetFromPage0 < offsetFromPage1)
                    {
                        return 1;
                    }
                    return 0;
                }
                else
                {
                    int offsetFromPage0 = cachePages[0].LowestIndex - rowIndex;
                    int offsetFromPage1 = cachePages[1].LowestIndex - rowIndex;
                    if (offsetFromPage0 < offsetFromPage1)
                    {
                        return 1;
                    }
                    return 0;
                }
    
            }
    
            // Returns a value indicating whether the given row index is contained
            // in the given DataPage. 
            private bool IsRowCachedInPage(int pageNumber, int rowIndex)
            {
                return rowIndex <= cachePages[pageNumber].HighestIndex &&
                    rowIndex >= cachePages[pageNumber].LowestIndex;
            }
