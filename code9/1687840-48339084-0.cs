    private double calculatePrice()
    {
        double sum = 0; //Double, because we are dealing with money, which is a decimal
    
        for(int i = 0; i < IngredientGrid.Rows.Count; i++)
        {
            sum += Convert.ToDouble(IngredientGrid.Rows[i].Cells[1].Value); //This takes the value of your selected cell within your ingredients datagrid (they need to be only numbers, no letters since we're converting to a double)
        }
        return sum;
    }
