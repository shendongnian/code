    private static bool TimeBlockIsOverLapping(DateTime newTimeBlockStart, DateTime newTimeBlockEnd, IEnumerable<TimeBlock> existingTimeBlocks) {
        foreach (var block in existingTimeBlocks) {
            // This is only if existingTimeBlocks are ordered. It is only
            // a speedup
            if (newTimeBlockStart > block.EndTime) {
                break;
            }
            // This is the real check. The ordering of the existingTimeBlocks
            // is irrelevant
            if (newTimeBlockStart <= block.EndTime && newTimeBlockEnd >= block.StartTime) {
                return true;
            }
        }
        return false;
    }
