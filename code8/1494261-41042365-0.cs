        static void Main(string[] args)
        {
            string[] columns = { "a", "b", "c", "d" };
            var headers = from column in columns
                          
                          let c_a = (dynamic)(column == "a" ? new { a = column } : null)
                          let c_b = (dynamic)(column == "b" ? new { b = column } : null)
                          let c_c = (dynamic)(column == "c" ? new { c = column } : null)
                          let c_d = (dynamic)(column == "d" ? new { d = column } : null)
                          select new
                          {
                              title = column,
                              filter = c_a ?? c_b ?? c_c ?? c_d,
                              show = true
                          };
            var filter_0 = headers.ElementAt(0).filter.a;
            var filter_1 = headers.ElementAt(1).filter.b;
            var filter_2 = headers.ElementAt(2).filter.c;
            var filter_3 = headers.ElementAt(3).filter.d;
        }
