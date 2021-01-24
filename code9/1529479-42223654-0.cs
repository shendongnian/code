    public class SqlScript
    {
        public async Task<DataTable> LoadDataAsync(string command, object value)
        {
            // Load data asynchronously by using ..Async methods
        }
    }
    private async Task loadComboAsync(string sqlComand, string value, ComboBox loadBox)
    {           
        var data = await sqlScript.LoadDataAsync(sqlComand, value);
         
        loadBox.ValueMember = columnNameWhichRepresentValue;
        loadBox.DataSource = data;
    }
    
