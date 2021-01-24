        static void Main(string[] args)
        {
            //0xE6100000010CA1342FE29618414034B3E08FEC4E5240
            var point = "E6100000010CA1342FE29618414034B3E08FEC4E5240";
            var pointBytes =  Enumerable.Range(0, point.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(point.Substring(x, 2), 16))
                     .ToArray();
            var sqlbytes = new SqlBytes(pointBytes);
            var sqlPoint = SqlGeography.Deserialize(sqlbytes);
            Console.WriteLine("SqlGeography = {0} - {1}", sqlPoint.Lat, sqlPoint.Long);
            DbGeography newGeography = DbGeography.FromText(sqlPoint.ToString(), DbGeography.DefaultCoordinateSystemId);
            Console.WriteLine("EF DBGeography = {0} - {1}", newGeography.Latitude, newGeography.Longitude);
            Console.ReadKey();
            
        }
