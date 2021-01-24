    GenericMethod(
        r => new GenericBudgetMatrixRow
            {
                EntityName = r.Field<string>(0),
                Values = r.ItemArray.Skip(1).Select(x => Convert.ToDecimal(x)).ToList(),
                Total = r.ItemArray.Skip(1).Select(x => Convert.ToDecimal(x)).Sum()
            }, 
        _matrixTemplate);
