    static void Main(string[] args)
        {
            DataTable dt1 = new DataTable(); //dt1=Customer
            dt1.Columns.Add("CustomerId", typeof(int));
            dt1.Columns.Add("Name", typeof(string));
            dt1.Rows.Add(1, "Customer A");
            dt1.Rows.Add(2, "Customer B");
            dt1.Rows.Add(3, "Customer C");
            DataTable dt2 = new DataTable();  //dt2=Order
            dt2.Columns.Add("OrderId", typeof(int));
            dt2.Columns.Add("CustomerId", typeof(int));  //Fk
            dt2.Columns.Add("OrderDate", typeof(DateTime));
            dt2.Columns.Add("OrderAmount", typeof(double));
            dt2.Rows.Add(1, 1,DateTime.Now,15000);
            dt2.Rows.Add(2, 1, DateTime.Now,10000);
            dt2.Rows.Add(3, 2, DateTime.Now,25000);
            var result = dt2.AsEnumerable()
                .Join(dt1.AsEnumerable(),
                x => x.Field<int>("CustomerId"), //Order(CustomerId) FK
                y => y.Field<int>("CustomerId"),  //Customer Id(Pk)
                (x, y) => new { dt2 = x, dt1 = y })  //dt2=Order, dt1=Customer
                .Select(x => new
                {
                    OrderId = x.dt2.Field<int>("OrderId"),
                    CustomerId = x.dt1.Field<int>("CustomerId"),
                    Name = x.dt1.Field<string>("Name"),
                    OrderDate = x.dt2.Field<DateTime>("OrderDate"),
                    OrderAmount = x.dt2.Field<double>("OrderAmount"),
                });
            foreach (var item in result)
            {
                Console.WriteLine("Order Id: {0}, CustomerId: {1}, Name: {2}, OrderDate: {3}, OrderAmount: {4}",
                    item.OrderId,item.CustomerId,item.Name,item.OrderDate,item.OrderAmount);
            }        
            Console.ReadKey();
        }
