    private void FillDataGridView()
    {
        refreshing = true; //To prevent data saving while generating the columns
        ... //Fill you DataGridView here            
        OrderColumns(); //Reorder the column from the file
        refreshing = false; //Then enable data saving when user will change the order
    }
