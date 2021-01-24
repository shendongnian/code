    public IEnumerable<PlannedSlot> GetOptimalDateSlots(OptimalDateSlotInput input) {
        var inputLoadAreas = new HashSet<string>(input.Locations.Select(d => d.id));
        var inputBundles = input.Locations.Select(d => d.bundles);
        var possibleSlots = _context.Slots.Where(slot => slot.From >= input.From && slot.To <= input.To &&
                                                      inputLoadAreas.Contains(slot.LoadArea))
                                           .Where(slot => inputBundles.Any(bundle => slot.RemainingCapacity > bundle));
        return possibleSlots;
    }
