          static void Main(string[] args)
        {
            string givenDateString = "01/26/2018";
            DateTime convertedDateFromString = new DateTime();
            DateTime.TryParse(givenDateString, out convertedDateFromString);
            DataTable dt = new DataTable();
            dt.Columns.Add("OurDate", typeof(System.DateTime));
            DataRow dR = dt.NewRow();
            dR["OurDate"] = DateTime.Now;
            dt.Rows.Add(dR);
            //way 1
            var result = from d in dt.AsEnumerable().ToList()
                         where d.Field<DateTime>("OurDate").Date == convertedDateFromString.Date
                         select d;
            Console.WriteLine(result.FirstOrDefault()["OurDate"].ToString());
            //way 2
            var result2 = from d in dt.AsEnumerable()
                          where d.Field<DateTime>("OurDate").Date == convertedDateFromString.Date
                          select d;
            //result.FirstOrDefault<DataRow>[""];
            Console.WriteLine(result2.FirstOrDefault<DataRow>()["OurDate"].ToString());
        }
