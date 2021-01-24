    class TestyComparer : IComparer<Testy> {
        int IComparer<Testy>.Compare(Testy x, Testy y)
        {
            if (x.Bla == y.Bla)
            {
                return 0;
            }
            else if (x.Bla > y.Bla)
            {
                return 1;
            }
            else // (x.Bla < y.Bla)
            {
                return -1;
            }
            //all lines works equals than:
            //return x.Bla < y.Bla
        }
    }
