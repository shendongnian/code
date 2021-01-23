            DataTable dt = new DataTable();
            dt.Columns.AddRange(
                new [] {
                    new DataColumn("a", typeof(string)),
                    new DataColumn("b", typeof(string)),
                    new DataColumn("c", typeof(string)),
                    new DataColumn("d", typeof(string)),
                    new DataColumn("e", typeof(string)),
                    new DataColumn("f", typeof(string)),
                    new DataColumn("g", typeof(string))
                });
            dt.Rows.Add("11111", "AS3000-5/100-400-P", "10.42.42.26", "SIM-001", "12345lkj", "alibaba", "abrakadabra");
            dt.Rows.Add("22222", "AS3000-5/100-400-Q", "10.42.42.158", null, null, null, null);
            mockReader = new DataTableReader(dt);
