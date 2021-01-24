    public class History
    {
        public int id { get; set; }
        public int value { get; set; }
        public DateTime date { get; set; }
    }
    // setup:
    var values = new List<History>();
    values.Add(new History() { id = 1, value = 1, date = DateTime.Parse("01/01/2017 20:20:20") });
    values.Add(new History() { id = 1, value = 2, date = DateTime.Parse("02/01/2017 20:20:20") });
    values.Add(new History() { id = 1, value = 3, date = DateTime.Parse("03/01/2017 20:20:20") });
    values.Add(new History() { id = 2, value = 5, date = DateTime.Parse("01/01/2017 20:20:20") });
    values.Add(new History() { id = 2, value = 6, date = DateTime.Parse("02/01/2017 20:20:20") });
    // result :
    values.GroupBy(
        x => x.id, 
        y => y.date,
        // Below, dates will be enumerable
        (id, dates) => new { id = id, date = dates.Max() }
    )
    // returns enumerable collection of anonymous type:
    {
        { id = 1, date = [3/1/2017 8:20:20 PM] }, 
        { id = 2, date = [2/1/2017 8:20:20 PM] }
    }
