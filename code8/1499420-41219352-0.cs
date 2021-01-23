    public class SectionModel
    {
        public string SectionId { get; set; }
        public int Code { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
    var list = dt.Rows.Select(d => new SectionModel
                {
                    SectionId = d[0],
                    Code = Convert.ToInt32(d[1]),
                    Date = Convert.ToDateTime(d[2]),
                    Value = Convert.ToDecimal(d[3])
                });
                var results = list.GroupBy(row => new {row.Date, row.Code}, (key, rows) => new
                {
                    period = key.Date,
                    code = key.Code,
                    value = rows.Sum(r => r.Value)
                })
                    .Where(r => r.code == codeParameter)
                    .ToList();
