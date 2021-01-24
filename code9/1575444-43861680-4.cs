            // grouping
            var groups = products.GroupBy(x => new
                                {
                                    Order = x.Order,
                                    GrandTotal = x.GrandTotal,
                                    Date = x.Date,
                                    Ship_FirstName = x.Ship_FirstName,
                                    Ship_LastName = x.Ship_LastName
                                })
                                .Select(item => new // flatten the group
                                        {
                                            Order = item.Key.Order,
                                            GrandTotal = item.Key.GrandTotal,
                                            Date = item.Key.Date,
                                            Ship_FirstName = item.Key.Ship_FirstName,
                                            Ship_LastName = item.Key.Ship_LastName,
                                            OrderItems = item.Select(i => new { Qty=i.Qty,Item=i.Item, Options = i.Options})
                                        })
                                .ToList();
            // binding to the outer repeater
            ParentRepeater.DataSource = groups;
            ParentRepeater.DataBind();
