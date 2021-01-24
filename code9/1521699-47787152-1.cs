    public IEnumerable<YOURMODEL> SortDataByColumn(IEnumerable<YOURMODEL> data, IDataTablesRequest request){
    
         var sortColumn = request.Columns.FirstOrDefault(s => s.Sort != null);
    
         if(sortColumn == null) return data;
    
         if (sortColumn.Sort.Direction == SortDirection.Descending)
         {
            return data.OrderByDescending(c => c.GetType().GetProperty(sortColumn.Field).GetValue(c));
         }
    
        return data.OrderBy(c => c.GetType().GetProperty(sortColumn.Field).GetValue(c));
    }
