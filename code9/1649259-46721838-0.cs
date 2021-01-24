    class Line
    {
        public int Length { get; set; }
        public double Height { get; set; }
        public void Add<O>(Expression<Func<Line, O>> accessor, dynamic scale) where O : struct
        {
            Add((accessor.Body as MemberExpression).Member.Name, scale);//simply get name from expression
        }
        public void Add(string name, dynamic scale)
        {
            var prop = typeof(Line).GetProperty(name);//can also get all members
            dynamic a = prop.GetValue(this);
            prop.SetValue(this, a * scale);
        }
    }
