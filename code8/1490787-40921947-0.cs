    public List<stockAJAX> returnList(string selectedGroupType, string selectedList, string selectedAmount)
    {
        //List of type <stock> this will contain all of the data to be put into the DataTable
    
    
    
        //Namespace utilising the TableEntities connection to the Entity Framework
        using (TableEntities context = new TableEntities())
        {
            //Lists which will contain data for the DropDownLists
            IList<SelectListItem> ddl = new List<SelectListItem>();
            IList<SelectListItem> ddl2 = new List<SelectListItem>();
    
            //Temp list of strings, used to grab data from the Entity to be placed into the dropdownlists
            List<string> stocktemp = null;
    
            //Query for the ProductGroup DropDownList
            stocktemp = (from c in context.stocks
                         select c.ProductGroup
                        ).Distinct().ToList();
            foreach (string item in stocktemp)  //Places data received in the SelectList as items
            {
                if (item == selectedList && item != null)       //Tests to see if the Item was selected in the last view, if so is set as default
                    ddl.Add(new SelectListItem() { Text = item, Selected = true });
                else if (item != null)
                    ddl.Add(new SelectListItem() { Text = item });
            }
            ViewData["list"] = ddl;         //PLaces the SelectList in the ViewData[]
    
    
            //Query for the GroupType DropDownList
            stocktemp = (from c in context.stocks
                         select c.GroupType
                        ).Distinct().ToList();
            foreach (string item in stocktemp)//Tests to see if the Item was selected in the last view, if so is set as default
            {
                if (item == selectedGroupType && item != null)
                    ddl2.Add(new SelectListItem() { Text = item, Selected = true });
                else if (item != null)
                    ddl2.Add(new SelectListItem() { Text = item });
            }
            ViewData["grouptype"] = ddl2;   //PLaces the SelectList in the ViewData[]
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
                    stock = stock.Where(c=>c.ProductGroup == selectedList);
                }
            }
            else if (selectedList == "list=Select+Company" || selectedList == null || selectedList == "")       //if select list is null, then no value was selected for Select Company
            {
                stock = stock.Where(c=>c.GroupType == selectedGroupType);
            }
            else                        //else if grouptype is not null, retrun data from query using groupType as the testing for GroupType
            {
                stock = stock
                  .Where(c=>c.ProductGroup == selectedList)
                  .Where(c=>c.GroupType == selectedGroupType);
            }
        }
        // Apply limit
        if (selectedAmount != "true") 
        {
          stock = stock
            .OrderByDescending(c=>c.DateArrived)
            .Take(1000);
        }
        // Do projection to DTO
        var result = stock.Select(c=>new stockAJAX
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
    
        //return the value to be used by the DataTable
        return result;
    }
