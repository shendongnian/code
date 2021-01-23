    void Main()
    {
    	DataTable workTable = new DataTable("Order");
    
    	DataColumn workCol = workTable.Columns.Add("BookingDate", typeof(String));
    	workTable.Columns.Add("Status", typeof(String));
    	workTable.Columns.Add("BookingNumber", typeof(int));
    	workTable.Rows.Add("2016/10/14","1",3);
    	workTable.Rows.Add("2016/10/14","1",1);
    	workTable.Rows.Add("2016/10/14","1",5);
    	workTable.Rows.Add("2016/10/13","1",7);
    	workTable.Rows.Add("2016/10/13","1",4);
    	workTable.Rows.Add("2016/10/12","1",8);
    	workTable.Rows.Add("2016/10/12","1",3);
    	workTable.Rows.Add("2016/10/12","1",6);
    	workTable.Rows.Add("2016/10/12","1",2);
    	
    	//========統計人數
    var count=workTable.AsEnumerable()
    .Select(x=>new { BookingDate= x.Field<string>("BookingDate"),BookingNumber = x.Field<int>("BookingNumber")})
    .GroupBy(x=>x.BookingDate)
    .Select(x=>new{BookingDate=x.Key,BookingNumber=x.Sum(s=>s.BookingNumber),Index=x.Count()}).OrderByDescending(x=>x.BookingDate).ToList();
    
    count.Dump();
    //========插入新的row
    int Position=0;
    foreach(var obj in count){
    	DataRow dr = workTable.NewRow();
    
    	dr[0] = obj.BookingDate;
    	dr[1] = "Total";
    	dr[2] = obj.BookingNumber;
    	Position +=obj.Index;
    	workTable.Rows.InsertAt(dr, Position);
    	Position++;
    }
    
    workTable.Dump();
    
    }
