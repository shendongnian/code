    public void SomeMethod(Expression<Func<Bla, bool>> param) {
        IEnumerable<Bla> query = quer.Where(e => e.actual == 1).Where(param);
        if (param != null) {
            query = query.Where(param);
        }
        // ...
    }
    // Usage
    SomeMethod(null);
    // or
    SomeMethod(bla => bla.Number > 5);
