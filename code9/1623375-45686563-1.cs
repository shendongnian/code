    class R1 : AC1
        {
            public R1(List<R2> r2s)
            {
                this.dammVariable = r2s;
                this.dammVariable= new List<AC2>();
                for(int i = 0; i<r2s.Count; i++)
                {
                    this.dammVariable[i] = r2s[i];
                }
            }
        }
