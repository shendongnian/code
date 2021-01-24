    [HttpPost]
        public FileResult Export()
        {       
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("CustomerId"),
                                                new DataColumn("ContactName"),
                                                new DataColumn("City"),
                                                new DataColumn("Country") });
     
            var customers = GetCustomers(); //get customer from database;
     
            foreach (var customer in customers)
            {
                dt.Rows.Add(customer.CustomerID, customer.ContactName, customer.City, customer.Country);
            }
     
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }
