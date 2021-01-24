    var result = list.GroupBy(x => new { x.BatchCode, x.BatchType }).Select(x => new BatchGroup
    {
        BatchCode = x.Key.BatchCode,
        BatchType = x.Key.BatchType,
        DetailRecordCountAdc = x.Count(y => y.RecType == RecType.Adc),
        DetailRecordCountNotAdc = x.Count(y => y.RecType == RecType.NotAdc),
        AmountAdc = x.Where(y => y.RecType == RecType.Adc).Sum(y => y.Amount),
        AmountNotAdc = x.Where(y => y.RecType == RecType.NotAdc).Sum(y => y.Amount)
    });
