    DomainService context = new DomainService();
    private void GetDataType()
    {
         var col = typeof(context.tblDetails).GetProperty("Name"); 
                string dataType = col.PropertyType.Name;
    }
