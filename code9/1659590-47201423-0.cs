    using System.Data;
    
    [...]
    
    // Create DataTable
    DataTable DataTable_Export = new DataTable();
    
    // Instert DataGrid into DataTable
    DataTable_Export= ((DataView)DataGrid_Input.ItemsSource).ToTable(); 
