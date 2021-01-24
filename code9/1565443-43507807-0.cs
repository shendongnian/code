    IList<Event> queryA = ( from e in context.CalenderEvents
                            join w in context.CalenderWeeks 
                              on e.CalenderWeek_Id equals w.Id
                            select new Event
                            {
                                Id = e.Id,
                                Year = w.Year,
                                Week = w.WeekNumber,
                                Title = e.Title,
                                Description = w.Description,
                            } ).ToList();
