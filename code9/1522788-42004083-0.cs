    public IEnumerable dataView()
    {
           PXView select = new PXView(this, true, DataView.View.BqlSelect);
           Int32 totalrow = 0;
           Int32 startrow = PXView.StartRow;
           List<object> result = select.Select(PXView.Currents, PXView.Parameters,        
           PXView.Searches, PXView.SortColumns, PXView.Descendings, 
           PXView.Filters, ref startrow, PXView.MaximumRows, ref totalrow);
           PXView.StartRow = 0;
           foreach (PXResult<Contract, ContractBillingSchedule, CSAnswers> row in result)
           {
                  //Do any dynamic calculations
           }
           return result;
    }
