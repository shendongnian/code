    class Model
    {
        public int Card;
        public int Department;
        public string PayDate;
        public char State;
    
        public Model(int c, int d, string p, char s)
        {
            Card = c;
            Department = d;
            PayDate = p;
            State = s;
        }
    }
    var list = new List<Model>
    {
        new Model(1, 25, "12 - 20 - 2016", 'A'),
        new Model(1, 25, "12 - 20 - 2016", 'B'),
        new Model(1, 25, "12 - 21 - 2016", 'D'),
        new Model(1, 30, "12 - 20 - 2016", 'A'),
        new Model(1, 30, "12 - 20 - 2016", 'X'),
        new Model(2, 10, "12 - 20 - 2016", 'B'),
        new Model(2, 15, "12 - 20 - 2016", 'A'),
        new Model(2, 15, "12 - 21 - 2016", 'E')
    };
    
    var result = list.GroupBy(x => x.Card).Select(z => 
    {
        return new
        {
            card = z.Key,
            departments = z.GroupBy(d => d.Department).Select(
                dd =>
                {
                    return new
                    {
                        department = dd.Key,
                        payDates = dd.GroupBy(pd => pd.PayDate)
                            .Select(
                                pdd =>
                                {
                                    return new {paydate = pdd.Key, states = pdd.Select(p => p.State)};
                                })
                    };
                })
        };
    });
