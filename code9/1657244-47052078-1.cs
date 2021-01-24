           var filteredQuery = (
                                from log in ctx.Loggings
                                where log.Datatype == 1 || log.Datatype == 2
                                orderby log.Id descending
                                select log
                                ).ToList();
            var items = new List<HeatmapViewModel>();
            for (int i = 1; i < filteredQuery.Count; i++)
            {
                if (filteredQuery[i].Datatype == 2 && filteredQuery[i - 1].Datatype == 1)
                {
                    TimeSpan differenceTicks = filteredQuery[i].CurDateTime - filteredQuery[i - 1].CurDateTime;
                    items.Add(new HeatmapViewModel
                    {
                        Latitude2 = filteredQuery[i].Longitude2,
                        Longitude2 = filteredQuery[i].Longitude2,
                        Difference = (int)differenceTicks.TotalMinutes
                    });
                }
            }
