    public List<stockAJAX> returnList(string selectedGroupType, string selectedList, string selectedAmount)
    {
        using (TableEntities context = new TableEntities())
        {
            // Do base query
            IQueryable<stock> stocks = context.stocks.AsQueryable();
            // Do filtering here
            if (selectedList == null && selectedGroupType == null)
            {
              // return all the records
            }
            else if (selectedGroupType == "grouptype=Select+GroupType" || selectedGroupType == null || selectedGroupType == "")     //If SelecteGroupType is NULL, then no value was selected for Select GroupType
            {
                if (selectedList == null || selectedList == "")     //if selectedList is also NULL return nothing
                {
                  // return all the records
                }
                else                    //Else, if selectedList is not null, return data from query using selectedList as the testing for ProductGroup
                {
                    stocks = stocks.Where(c=>c.ProductGroup == selectedList);
                }
            }
            else if (selectedList == "list=Select+Company" || selectedList == null || selectedList == "")       //if select list is null, then no value was selected for Select Company
            {
                stocks = stocks.Where(c=>c.GroupType == selectedGroupType);
            }
            else                        //else if grouptype is not null, retrun data from query using groupType as the testing for GroupType
            {
                stocks = stocks
                  .Where(c=>c.ProductGroup == selectedList)
                  .Where(c=>c.GroupType == selectedGroupType);
            }
          // Apply limit
          if (selectedAmount != "true") 
          {
            stocks = stocks
              .OrderByDescending(c=>c.DateArrived)
              .Take(1000);
          }
          // Do projection to DTO
          var result = stocks.Select(c=>new stockAJAX
          {
            StockId = c.StockId,
            ProductGroup = c.ProductGroup,
            GroupType = c.GroupType,
            ItemType = c.ItemType,
            Model = c.Model,
            SerialNo = c.SerialNo,
            NR = c.NR,
            Status = c.Status.ToString(),
            Description = c.Description,
            DateArrived = c.DateArrived.ToString(),
            CurrentLocation = c.CurrentLocation,
            TerminalId = c.TerminalId,
          }).ToList();
        }
   
        //return the value to be used by the DataTable
        return result;
    }
