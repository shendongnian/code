    var list = ptList.select(p => new{
    		DateTime = p._dateDt,
    		Status = p._statStr,
    		Value = p._valDoub,
    		Key = p._pointName
    	});
    using(var connection = new SqlConnection...)
    {
      connection.open()
      connection.Execute("update [CCVT].[dbo].[_tb_NCVT_Points] set PointDateTime = @DateTime, PointStatus = @Status, PointValue = @Value
     WHERE Pointkey = @Key", list);
    }
