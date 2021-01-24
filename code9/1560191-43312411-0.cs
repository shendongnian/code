        public MyModel GetBy(Func<MyModel, bool> predicate) {
                    return GetAll().SingleOrDefault(predicate);
                }
    
    GetBy(m => m.Name.Equals("Foo", StringComparison.OrdinalIgnoreCase));
