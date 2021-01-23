    var result = dt
      .AsEnumerable()
      .Select(record => new {
         Column1 = Convert.ToInt32(record["Column1"]),
         Column2 = Convert.ToString(record["Column2"]) }) 
      .Where(item => item.Column2 == "A" || item.Column2 == "B")
      .Where(item => item.Column1 < 10) 
      .Sum(item => Math.Abs(item.Column1));
