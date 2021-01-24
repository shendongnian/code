    public IHttpActionResult GetOptimalDateSlot(OptimalDateSlotInput input) {
        var inputAreas = input.Locations.Select(d => d.id).ToList();
        var optimalSlots = GetOptimalDateSlots(input).GroupBy(slot => slot.From)
                                                     .Where(slotg => inputAreas.All(a => slotg.Any(slot => slot.LoadArea == a)));
        var slotsToReturn = Mapper.Map<IEnumerable<PlannedSlotDto>>(optimalSlots);
    
        return Ok(optimalSlots);
    }
