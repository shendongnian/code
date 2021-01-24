    protected void rg_CustomAggregate(object sender, GridCustomAggregateEventArgs e)
    {
      if (e.Item is GridGroupFooterItem)
      {
        GridGroupFooterItem gridFooterItem = e.Item as GridGroupFooterItem;
        GridItem[] groupHeaders = rg.MasterTableView.GetItems(GridItemType.GroupHeader);
        foreach (GridGroupHeaderItem groupHeader in groupHeaders)
        {
          if (groupHeader.GroupIndex == gridFooterItem.GroupIndex)
          {
            decimal groupSum = 0;
            foreach (GridItem childItem in groupHeader.GetChildItems())
            {
              FunctionSummaryDTO functionSummary = (FunctionSummaryDTO)childItem.DataItem;
              if (functionSummary.UpfrontPayment == false)
              {
                groupSum += functionSummary.InvoiceAmount;
              }
            }
            e.Result = groupSum;
          }
        }
      }
      if (e.Item is GridFooterItem)
      {
        decimal totalSum = 0;
        GridItem[] groupFooters = rg.MasterTableView.GetItems(GridItemType.GroupFooter);
        foreach (GridGroupFooterItem groupFooter in groupFooters)
        {
          decimal parseBuffer = 0;
          decimal.TryParse(groupFooter["colInvoiceAmount"].Text, out parseBuffer);
          totalSum += parseBuffer;
        }
        e.Result = totalSum;
      }
    }
