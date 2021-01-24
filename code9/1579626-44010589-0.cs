            var dt = new DataTable();
            
            var dc = new DataColumn("Age", typeof(int));
            dt.Columns.Add(dc);
            var dr = dt.NewRow();
            dr["Age"] = "test"; // throws an ArgumentException
            //Input string was not in a correct format. Couldn't store<test> in Age Column.  Expected type is Int32.
