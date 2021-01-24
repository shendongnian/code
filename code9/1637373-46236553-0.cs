     public List<Summary> GetSummary()
            {
                List<Summary> summ = new List<Summary>();
                summ = (
                            from list1 in GetList1()
                            join list2 in GetList2() on list1.ID equals list2.ID
                            select new
                            {
                                ID = list1.ID,
                                Quantity = list1.Quantity,
                                Weight = list2.Weight,
                                Time = list1.Time
                            }
                            into list
                            group list by new { list.ID } into g
                            select new Summary
                            {
                                ID = g.Key.ID,
                                ItemCount = g.Count(),
                                Quantity = g.Sum(x => x.Quantity),
                                Weight = g.Sum(x => x.Weight),
                                Time = TimeSpan.FromHours(Convert.ToDouble(g.Sum(x => x.Time))).ToString(@"dd\.hh\:mm\:ss"),
                            }
                          ).ToList();
    
                return summ;
            }
