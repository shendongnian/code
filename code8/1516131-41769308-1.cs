    dynamic[] allData = new dynamic[6];
    for (int i = 0; i < allData.Length; i++)
    {
        allData[i] = GetDataArray(
            r.rateEvalDLoc.rateEvalOLoc.charge.Total,
            r.rateEvalDLoc.rateEvalOLoc.charge.Total,
            r.rateEvalDLoc.originLoc.LocationName.ToString(),
            r.rateEvalDLoc.originLoc.LocationName.ToString(),
            r.destinationLoc.LocationName.ToString(),
            r.destinationLoc.LocationName.ToString());
    }
    sizesDict.Add(eDate, allData);
