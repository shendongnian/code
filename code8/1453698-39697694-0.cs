            public int rt;
            public object o;
            public int? pr { get { return rt == 1 ? (int?)o : null; } }
            public int? nr { get { return rt == 0 ? (int?)o : null; } }
        }
`
