    // static: we don't want "this" in the context
    private static bool TimeBlockIsOverLapping(DateTime newTimeBlockStart, 
                                               DateTime newTimeBlockEnd, 
                                               IEnumerable<TimeBlock> existingTimeBlocks) {
      if (null == existingTimeBlocks)
        return false;
      else if (newTimeBlockStart > newTimeBlockEnd)
        return false;
      // assuming that there' no null blocks within existingTimeBlocks
      // and all blocks within existingTimeBlocks are valid ones
      foreach (var block in existingTimeBlocks) {
        //TODO: check edges: < or <=; > or >=
        if ((newTimeBlockStart < block.EndTime) && (newTimeBlockEnd > block.StartTime))
          return true; // overlap found
      }  
      return false; // no overlap found  
    }
