      var slotsSchedules = dbContext.Slots.ToList().Select(slot => new { 
                           SlotID = slot.Id, 
                           Name = slot.Name,
                           SlotSchedules = dbContext.Schedules.ToList()
                                          .Where(schedule = > schedule.SlotId == slot.Id).ToList()});
  
