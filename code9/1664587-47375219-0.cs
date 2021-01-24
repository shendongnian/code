    DataTable table = new DataTable();
    ....
    private void filldata()
    {
        .....
        // This creates a local DataTable variable with the same name of the global one
        // You are hiding the global and using the local one
        // DataTable table = new DataTable();
        // here instead you use the global variable
        // So you are referencing the same variable in the SelectedIndexChanged handler
        table = new DataTable();
        ....
    }
