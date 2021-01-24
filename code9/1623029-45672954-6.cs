    private static bool SatisfiesCondition(Foo r, Bar s, Baz datumod2, Baz datumted2) {
        if (!r.Reserved.IsReserved)
            return true;
        if (s.Id != r.Reserved.Id)
            return false;
        if (datumod2 == datumted2)
            return true;
        return DateTime.Now.IsInside(r.DateFrom, r.DateTo);
    }
