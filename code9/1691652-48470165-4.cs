    DateTime Max(DateTime a, DateTime b) => (a > b) ? a : b;
    DateTime Min(DateTime a, DateTime b) => (a < b) ? a : b;
    
    int OverlappingDays((DateTime DateFrom, DateTime DateTo) span1, (DateTime DateFrom, DateTime DateTo) span2) {
        var maxFrom = Max(span1.DateFrom, span2.DateFrom);
        var minTo = Min(span1.DateTo, span2.DateTo);
        return Math.Max((minTo - maxFrom).Days, 0);
    }
