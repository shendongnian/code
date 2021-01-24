    bool allRangeHasValue=true;
    for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
    {
        for(int col =1;col<=s.Dimension.End.Column;col++)
        {
          if(String.IsNullOrWhiteSpace(s.Cells[rowIterator, col]?.Value?.ToString())
          {
              allRangeHasValue=false;
              break;
          }
        }
        if(!allRangeHasValue)
        {
          break;
        }
    }
