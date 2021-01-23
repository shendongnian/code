    conn.SCOT_DADOS.GroupBy(x => x.User).Select(x => new
                    {
                        User = x.Key,
                        Date = list.Where(y => y.User == x.Key).Max(y => y.Date)
                    });
