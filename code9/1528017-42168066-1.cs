    var list = new[]
    {
        new Batch
        {
            BatchCode = 1234,
            BatchType = BatchType.Scanned,
            Amount = 10.00,
            RecType = RecType.Adc
        },
        new Batch
        {
            BatchCode = 1234,
            BatchType = BatchType.Scanned,
            Amount = 5.00,
            RecType = RecType.NotAdc,
        },
        new Batch
        {
            BatchCode = 2222,
            BatchType = BatchType.NonScanned,
            Amount = 25.00,
            RecType = RecType.Adc,
        },
        new Batch
        {
            BatchCode = 2222,
            BatchType = BatchType.NonScanned,
            Amount = 30.01,
            RecType = RecType.NotAdc,
        }
    };
