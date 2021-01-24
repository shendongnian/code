    foreach (var item in results)
    {
        var sample = (HKQuantitySample) item;
        var hkUnit = HKUnit.Count.UnitDividedBy(HKUnit.Count);
        var quantity = sample.Quantity.GetDoubleValue(hkUnit);
        var startDateTime = sample.StartDate.ToDateTime().ToLocalTime();
        var endDateTime = sample.EndDate.ToDateTime().ToLocalTime();
        Debug.WriteLine(quantity);
        Debug.WriteLine(startDateTime);
        Debug.WriteLine(endDateTime);
    }
