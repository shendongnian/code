    class ObjComparer
        : IComparer<Obj>
    {
        public int Compare(Obj x, Obj y)
        {
            int compare = CompareByProperties(x, y);
            if (compare == 0)
            {
                compare = CompareByDate(x.StartDate, y.StartDate);
                if (compare == 0)
                {
                    compare = CompareByDate(x.EndDate, y.EndDate);
                }
            }
            return compare;
        }
    
        static int CompareByProperties(Obj o1, Obj o2)
        {
            return MainIsTrueAndEndDateIsNull(o1) ?
                    (MainIsTrueAndEndDateIsNull(o2) ? 0 : 1) :
                    (MainIsTrueAndEndDateIsNull(o2) ? -1 : 0);
        }
    
        static bool MainIsTrueAndEndDateIsNull(Obj o)
        {
            return o.Main.Value && o.EndDate == null;
        }
    
        static int CompareByDate(DateTime? d1, DateTime? d2)
        {
            return d1 == d2 ? 0 : (d1 > d2 ? 1 : -1);
        }
    }
