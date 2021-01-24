    class MyComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            var proerties = this.GetType().GetProperties().Where(x => Attribute.IsDefined(x, typeof(MyAttribute));
            var equal = true;
            foreach(var p in properties)
               equal &= p.GetValue(x, null) == p.GetValue(y, null);
            return equal;
        }
    }
