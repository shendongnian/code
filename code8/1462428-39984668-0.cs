    var tables = new List<Table1>();
                foreach (var item in items)
                {
                    var t1 = new Table1
                    {
                        P1 = item.P1,
                        P2 = item.P2,
                        P3 = item.P3,
                        Table2s = new List<Table2>()
                    };
                    
                    var p4Group = item.P4s.GroupBy(pt => new {pt.T1, pt.T2 });
                    foreach (var p4 in p4Group)
                    {
                        var table2 = new Table2
                        {
                            T1 = p4.Key.T1,T2 = p4.Key.T2, Table3s = new List<Table3>()
                        };
                        var p4S = p4.ToList();
                        foreach (var p4FromGroup in p4S)
                        {
                            table2.Table3s.Add(new Table3
                            {
                                T3 = p4FromGroup.T3,
                                T4 = p4FromGroup.T4
                            });
                        }
                        
                        t1.Table2s.Add(table2);
                    }
                    tables.Add(t1);
                }
